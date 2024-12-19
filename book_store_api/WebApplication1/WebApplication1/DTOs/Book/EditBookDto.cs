using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Book;

public class EditBookDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [Range(1000, 9999)]
    public decimal Price { get; set; }
    public DateTime PublishedDate { get; set; }
    public int Stock { get; set; }
    public int AuthorId { get; set; }
    public int CatalogId { get; set; }
}