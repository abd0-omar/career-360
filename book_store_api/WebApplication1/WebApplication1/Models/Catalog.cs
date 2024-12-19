using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Catalog
{
    // aka category
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? Desc { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}