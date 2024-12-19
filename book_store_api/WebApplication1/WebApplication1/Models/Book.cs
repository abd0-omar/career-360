using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    [ForeignKey("author")]
    public int AuthorId { get; set; }
    [ForeignKey("catalog")]
    public int CatalogId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime PublishDate { get; set; }

    public virtual Author? Author { get; set; }
    public virtual Catalog? Catalog { get; set; }
    public virtual List<OrderDetails> OrderDetailsList { get; set; } = new List<OrderDetails>();
}