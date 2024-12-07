using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(KompanyContext db) : Controller
{
    private readonly KompanyContext _db = db;

    [HttpPost]
    public ActionResult add_emp_with_photo(AddEmployeeDTO employeeDto)
    {
        if (employeeDto.file.Length == 0)
        {
            return BadRequest();
        }

        var filePath = $"{Directory.GetCurrentDirectory()}/{employeeDto.file.FileName}";
        FileStream fs = new FileStream(filePath, FileMode.Create);
        employeeDto.file.CopyTo(fs);
        
        var employee = new Employee()
        {
            username = employeeDto.username,
            photo = filePath,
            date = employeeDto.date,
            email = employeeDto.email,
            password = employeeDto.password,
            salary = employeeDto.salary,
            name = employeeDto.name,
        };
        // create image file path
        // add file path to db
        _db.Add(employee);
        _db.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public ActionResult<ShowEmployeeDTO> GetAll()
    {
        var employees = _db.Employees.ToList();
        var employeesDto = new List<ShowEmployeeDTO>();
        foreach (var emp in employees)
        {
            var employeeDto = new ShowEmployeeDTO()
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
    public ActionResult<ShowEmployeeDTO> GetById([FromRoute]int id)
    {
        var employee = _db.Employees.SingleOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDto = new ShowEmployeeDTO()
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
}