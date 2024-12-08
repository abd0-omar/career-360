using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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
    public EmployeeController(UnitOfWork unitOfWork, EmployeeRepository employeeRepository)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
    }
    
    [HttpPost]
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
    public ActionResult<BasicEmployeeDTO> GetAll()
    {
        // reps
        var employees = _unitOfWork.EmpRep.GetAll();
        var employeesDto = new List<BasicEmployeeDTO>();
        foreach (var emp in employees)
        {
            var employeeDto = new BasicEmployeeDTO()
            {
                name = emp.name,
                photo = emp.photo,
                date = emp.date,
                email = emp.email,
                password = emp.password,
                salary = emp.salary,
                username = emp.username
            };
            employeesDto.Add(employeeDto);
        }
        return Ok(employeesDto);
    }
    
    [HttpGet("{id:int}")]
    public ActionResult<BasicEmployeeDTO> GetById([FromRoute]int id)
    {
        // reps
        var employee = _unitOfWork.EmpRep.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDto = new BasicEmployeeDTO()
        {
            name = employee.name,
            photo = employee.photo,
            date = employee.date,
            email = employee.email,
            password = employee.password,
            salary = employee.salary,
            username = employee.username
        };
        return Ok(employeeDto);
    }

    [HttpPut]
    public ActionResult Edit(Employee employee)
    {
        _unitOfWork.EmpRep.Edit(employee);
        _unitOfWork.Save();
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        if (!_unitOfWork.EmpRep.Delete(id)) return NotFound();
        _unitOfWork.Save();
        return Ok();
    }

    [Route("extra_route")]
    [HttpPost]
    public ActionResult Add(BasicEmployeeDTO employeeDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var employee = new Employee()
        {
            username = employeeDto.username,
            photo = employeeDto.photo,
            password = employeeDto.password,
            salary = employeeDto.salary,
            name = employeeDto.name,
            date = employeeDto.date,
            email = employeeDto.email,
        };
        _unitOfWork.EmpRep.Add(employee);
        _unitOfWork.Save();
        return Ok();
    }
}