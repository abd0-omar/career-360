using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class KompanyContext: DbContext
{
    public virtual DbSet<Employee> Employees { get; set; }
    // both empty
    public KompanyContext()
    {
        
    }


    public KompanyContext(DbContextOptions<KompanyContext> options) : base(options)
    {
        
    }
}
