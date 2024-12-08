using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(EmployeeRepistory empReps) : Controller
{
    private readonly EmployeeRepistory _empReps = empReps;

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
        _empReps.AddEmployee(employeeDto, filePath);
        return Ok();
    }

    [HttpGet]
    public ActionResult<ShowEmployeeDTO> GetAll()
    {
        // reps
        var employees = _empReps.GetAll();
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
        // reps
        var employee = _empReps.GetById(id);
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