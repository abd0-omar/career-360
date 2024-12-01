using Microsoft.EntityFrameworkCore;

namespace EFDay02_CodeFIrst.Models;

public class NewsContext : DbContext
{
    public NewsContext()
    {
    }

    // virtual for the lazy loading
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<News> News { get; set; }
    public virtual DbSet<Catalog> Catalogs { get; set; }

    // configure connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
            "Server=BODBOD\\SQLEXPRESS;Database=code_first_news;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //     // how to add composite primary key
        // modelBuilder.Entity<Catalog>().HasKey("name", "desc");
        
        modelBuilder.Entity<Author>().HasData(
            new Author()
            {
                id = 1, name = "abood", bref = "3",
                password = "hamada123", username = "hamada",
                joinDate = new DateTime(2001, 1, 1)
            }
        );
    
        modelBuilder.Entity<Catalog>().HasData(
            new Catalog()
            {
                 id = 1, name = "kataloog", desc = "ok",
            });
        modelBuilder.Entity<News>().HasData(
            new News()
            {
                 id = 1, AuthorId = 1, bref = "m4 3aref", desc = "eh dh",
                 title = "3enwan", datetime = new DateTime(2005, 5, 5),CatalogId = 1
            });
    }
}