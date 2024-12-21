using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class TodoContext: DbContext
{
    public virtual DbSet<Todo> Todos { get; set; }
    public TodoContext()
    {
        
    }

    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {
        
    }
}