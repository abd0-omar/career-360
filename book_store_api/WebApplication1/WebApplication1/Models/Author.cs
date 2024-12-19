using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Author
{
    public int Id { get; set; }
    [Required]
    public required string FullName { get; set; }
    public string? Bio { get; set; }
    public int Age { get; set; }
    public int NumOfBooks { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}