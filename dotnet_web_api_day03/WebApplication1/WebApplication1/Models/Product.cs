using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("Catalog")]
    public int CatalogId { get; set; }
    public virtual Catalog Catalog { get; set; }
}
