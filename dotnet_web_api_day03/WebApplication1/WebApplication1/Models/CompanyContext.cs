using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class CompanyContext: DbContext
{
    public virtual DbSet<Catalog> Catalogs { get; set; }
    public virtual DbSet<Product?> Products { get; set; }
    // public virtual DbSet<Student> {get; set}
    
    // connection string
    // override on configuration
    // use lazyloading or use sqlserver
    // options.builder.useLazygloading("connection string") or usesqlserver
    // server=BODBOD\\SQLEXPRESS;database=students;user id=abdo;password=password;trustservercertificate=true;
    // 
    
    // dpendency injection
    public CompanyContext(DbContextOptions<CompanyContext> option): base(option)
    {
        
    }
    
    
}