using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.DTOs.ProductDTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(CompanyContext db) : Controller
{
[HttpGet]
public ActionResult<List<Product>> GetAll()
{
    var products = db.Products.ToList();
    if (products.Count == 0) return NotFound();

    List<DisplayProductDTO> productsDto = new List<DisplayProductDTO>();
    foreach (var product in products)
    {
        DisplayProductDTO productDto = new DisplayProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            CatalogId = product.CatalogId,
            CatalogName = product.Catalog.Name
        };
        
        // Add to the DTO list
        productsDto.Add(productDto);
    }

    return Ok(productsDto);
}

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = db.Products.SingleOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        DisplayProductDTO productDto = new DisplayProductDTO()
        {
            Id = product.Id,
            CatalogId = product.CatalogId,
            Quantity = product.Quantity,
            Price = product.Price,
            Name = product.Name,
            CatalogName = product.Catalog.Name
        };
        return Ok(productDto);
    }

    [HttpPost]
    public IActionResult Add(AddProductDTO productDto)
    {
        if (productDto == null) return BadRequest();
        Product product = new Product()
        {
            Name = productDto.Name,
            CatalogId = productDto.CatalogId,
            Quantity = productDto.Quantity,
            Price = productDto.Price,
            Id = productDto.Id
        };
        db.Products.Add(product);
        db.SaveChanges();
        
        return Ok();
    }
}