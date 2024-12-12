using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class UnitOfWork(KompanyContext db)
{
    // have all generic repos of different object models
    private GenericRepository<Employee> _empRep;

    public GenericRepository<Employee> EmpRep
    {
        get
        {
            if (_empRep == null) _empRep = new GenericRepository<Employee>(db);
            return _empRep;
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }
}