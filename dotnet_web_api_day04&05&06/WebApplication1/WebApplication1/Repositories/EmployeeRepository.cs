using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class EmployeeRepository(KompanyContext db)
{
    // this class exist because emp add has a specific use case
    public void AddEmployee(AddEmployeeDTO employeeDto, string filePath)
    {
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
        db.Add(employee);
        db.SaveChanges();
    }
}