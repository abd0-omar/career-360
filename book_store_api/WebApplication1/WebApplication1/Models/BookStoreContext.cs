using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class BookStoreContext: IdentityDbContext
{
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books {get; set;}
    public virtual DbSet<Catalog> Catalogs {get; set;}
    public virtual DbSet<Customer> Customers {get; set;}
    public virtual DbSet<Order> Orders {get; set;}
    // suggested name by rider
    public virtual DbSet<OrderDetails> OrderDetailsEnumerable {get; set;}
    public BookStoreContext()
    {
        
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // change enums from int to string
        builder.Entity<Order>().Property(o => o.Status).HasConversion<string>();
        builder.Entity<OrderDetails>().HasKey("BookId", "OrderId");
        // doesn't work for some reason
        // builder.Entity<IdentityRole>().HasData(
        //     new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "admin", NormalizedName = "ADMIN" },
        //     new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "customer", NormalizedName = "CUSTOMER" }
        // );
        builder.Entity<Catalog>().HasData(
            new Catalog {Id = 1, Name = "sport", Desc = "wow"}
        );
    }
}