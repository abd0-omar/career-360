using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Book;

public class AddBookDto
{
    public required string Title { get; set; }
    [Range(1000, 9999)]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime PublishDate { get; set; }
    public required int AuthorId { get; set; }
    public required int CatalogId { get; set; }
}