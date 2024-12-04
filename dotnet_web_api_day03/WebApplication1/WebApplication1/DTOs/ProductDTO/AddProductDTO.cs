namespace WebApplication1.DTOs.ProductDTO;

public class AddProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int CatalogId { get; set; }
}