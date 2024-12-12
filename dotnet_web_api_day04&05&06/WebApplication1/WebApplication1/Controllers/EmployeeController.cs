using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly UnitOfWork _unitOfWork;
    private readonly EmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeController(UnitOfWork unitOfWork, EmployeeRepository employeeRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Add an employee with a photo",
        Description = "Uploads a photo and adds a new employee with the provided data.",
        OperationId = "AddEmployeeWithPhoto",
        Tags = new[] { "Employees" }
    )]
    [SwaggerResponse(200, "Employee added successfully")]
    [SwaggerResponse(400, "Invalid input or file missing")]
    [Consumes("multipart/form-data")]
    public ActionResult add_emp_with_photo(AddEmployeeDTO employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (employeeDto.file.Length == 0)
        {
            return BadRequest();
        }
        var filePath = $"{Directory.GetCurrentDirectory()}/{employeeDto.file.FileName}";
        FileStream fs = new FileStream(filePath, FileMode.Create);
        employeeDto.file.CopyTo(fs);
        
        // reps
        // won't use generic here, as it's not easy to generalize this case
        _employeeRepository.AddEmployee(employeeDto, filePath);
        return Ok();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all employees",
        Description = "Retrieves a list of all employees.",
        OperationId = "GetAllEmployees",
        Tags = new[] { "Employees" }
    )]
    [SwaggerResponse(200, "Returns the list of employees", typeof(List<BasicEmployeeDTO>))]
    [Produces("application/json")]
    public ActionResult<List<BasicEmployeeDTO>> GetAll()
    {
        var employees = _unitOfWork.EmpRep.GetAll();
        // var employeesDto = employees.Select(emp => new BasicEmployeeDTO
        // {
        //     name = emp.name,
        //     photo = emp.photo,
        //     date = emp.date,
        //     email = emp.email,
        //     password = emp.password,
        //     salary = emp.salary,
        //     username = emp.username
        // }).ToList();
        var employeesDto = _mapper.Map<List<BasicEmployeeDTO>>(employees);
        if (employeesDto != null)
        {
            return Ok(employeesDto);
        }
        return NotFound();
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Get employee by ID",
        Description = "Retrieves details of an employee by their ID.",
        OperationId = "GetEmployeeById",
        Tags = new[] { "Employees" }
    )]
    [SwaggerResponse(200, "Returns the employee details", typeof(BasicEmployeeDTO))]
    [SwaggerResponse(404, "Employee not found")]
    public ActionResult<BasicEmployeeDTO> GetById([FromRoute] int id)
    {
        // reps
        var employee = _unitOfWork.EmpRep.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        // var employeeDto = new BasicEmployeeDTO()
        // {
        //     name = employee.name,
        //     photo = employee.photo,
        //     date = employee.date,
        //     email = employee.email,
        //     password = employee.password,
        //     salary = employee.salary,
        //     username = employee.username
        // };
        var employeeDto = _mapper.Map<BasicEmployeeDTO>(employee);
        return Ok(employeeDto);
    }

    [HttpPut]
    [SwaggerOperation(
        Summary = "Edit an employee",
        Description = "Edits the details of an existing employee.",
        OperationId = "EditEmployee",
        Tags = new[] { "Employees" }
    )]
    [SwaggerResponse(200, "Employee edited successfully")]
    [SwaggerResponse(400, "Invalid input")]
    [Consumes("application/json")]
    public ActionResult Edit([FromBody] Employee employee)
    {
        _unitOfWork.EmpRep.Edit(employee);
        _unitOfWork.Save();
        return Ok();
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Delete an employee",
        Description = "Deletes an employee by their ID.",
        OperationId = "DeleteEmployee",
        Tags = new[] { "Employees" }
    )]
    [SwaggerResponse(200, "Employee deleted successfully")]
    [SwaggerResponse(404, "Employee not found")]
    public ActionResult Delete([FromQuery] int id)
    {
        if (!_unitOfWork.EmpRep.Delete(id)) return NotFound();
        _unitOfWork.Save();
        return Ok();
    }

    [Route("extra_route")]
    [HttpPost]
    [SwaggerOperation(
        Summary = "Add a basic employee",
        Description = "Adds an employee with basic details.",
        OperationId = "AddBasicEmployee",
        Tags = new[] { "Employees" }
    )]
    [SwaggerResponse(200, "Employee added successfully")]
    [SwaggerResponse(400, "Invalid input")]
    [Consumes("application/json")]
    public ActionResult Add([FromBody] BasicEmployeeDTO employeeDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        // var employee = new Employee()
        // {
        //     username = employeeDto.username,
        //     photo = employeeDto.photo,
        //     password = employeeDto.password,
        //     salary = employeeDto.salary,
        //     name = employeeDto.name,
        //     date = employeeDto.date,
        //     email = employeeDto.email,
        // };
        var employee = _mapper.Map<Employee>(employeeDto);
        _unitOfWork.EmpRep.Add(employee);
        _unitOfWork.Save();
        return Ok();
    }
}