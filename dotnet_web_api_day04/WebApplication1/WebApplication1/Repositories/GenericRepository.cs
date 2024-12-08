using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class GenericRepository<TEntity>(KompanyContext db) where TEntity: class
{
    private readonly KompanyContext _db = db;
    
    // this function has to be non generic
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
    
    // public void AddEmployee(TEntity entity, string filePath)
    // {
    //     _db.Set<TEntity>().Add(entity);
    //     _db.SaveChanges();
    // }

    public List<TEntity> GetAll() => _db.Set<TEntity>().ToList();

    public TEntity? GetById(int id) => _db.Set<TEntity>().Find(id);
}