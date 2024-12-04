﻿namespace WebApplication1.DTOs.ProductDTO;

public class DisplayProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int CatalogId { get; set; }
    public string CatalogName { get; set; }
}