using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs._Author;

public class AddAuthorDto
{
    [Required]
    public  required string FullName { get; set; }
    public string? Bio { get; set; }
    public int Age { get; set; }
    public int NumOfBooks { get; set; }
}