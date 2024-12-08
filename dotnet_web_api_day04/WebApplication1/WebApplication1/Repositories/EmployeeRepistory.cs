using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class EmployeeRepistory(KompanyContext db)
{
    private KompanyContext _db = db;
    
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
        _db.Add(employee);
        _db.SaveChanges();
    }

    public List<Employee> GetAll() => _db.Employees.ToList();

    public Employee? GetById(int id) => _db.Employees.SingleOrDefault(emp => emp.Id == id);
}