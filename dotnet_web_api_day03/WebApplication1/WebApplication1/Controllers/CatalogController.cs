using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController(CompanyContext db) : Controller
{
    [HttpGet]
    public ActionResult<DisplayCatalogDTO> GetAll()
    {
        List<Catalog> catalogs = db.Catalogs.ToList();
        List<DisplayCatalogDTO> catalogsDto = new List<DisplayCatalogDTO>();
        foreach (var catalog in catalogs)
        {
            DisplayCatalogDTO catalogDto = new DisplayCatalogDTO()
            {
                id = catalog.Id,
                name = catalog.Name,
                desc = catalog.Desc,
                productNames = catalog.Products.Select(p => p.Name).ToList(),
            };
            catalogsDto.Add(catalogDto);
        }
        return Ok(catalogsDto);
    }

    [HttpGet("{id}")]
    public ActionResult<DisplayCatalogDTO> GetById(int id)
    {
        var catalog = db.Catalogs.SingleOrDefault(c => c.Id == id);
        if (catalog == null)
        {
            return NotFound();
        }

        DisplayCatalogDTO catalogDto = new DisplayCatalogDTO()
        {
            id = catalog.Id,
            name = catalog.Name,
            desc = catalog.Desc,
            productNames = catalog.Products.Select(p => p.Name).ToList()
        };
        return Ok(catalogDto);
    }
}