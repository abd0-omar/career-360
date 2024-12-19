using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.UnitOfWorks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.DTOs.Catalog;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController(UnitOfWork unitOfWork) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet]
    [SwaggerOperation(Summary = "Get all catalogs")]
    [SwaggerResponse(200, "Catalogs retrieved successfully")]
    [SwaggerResponse(404, "No catalogs found")]
    public ActionResult GetAll()
    {
        var catalogs = unitOfWork.CatalogRepo.GetAll();
        if (catalogs.Count == 0) return NotFound();
        var viewCatalogsDto = new List<ViewCatalogDto>();
        foreach (var catalog in catalogs)
        {
            var viewCatalogDto = new ViewCatalogDto()
            {
                Id = catalog.Id,
                Name = catalog.Name,
                Desc = catalog.Desc
            };
            viewCatalogsDto.Add(viewCatalogDto);
        }

        return Ok(viewCatalogsDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a catalog by ID")]
    [SwaggerResponse(200, "Catalog retrieved successfully")]
    [SwaggerResponse(404, "Catalog not found")]
    public ActionResult GetById(int id)
    {
        var catalog = unitOfWork.CatalogRepo.GetById(id);
        if (catalog == null) return NotFound();

        var viewCatalogDto = new ViewCatalogDto()
        {
            Id = catalog.Id,
            Name = catalog.Name,
            Desc = catalog.Desc
        };

        return Ok(viewCatalogDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpPost]
    [SwaggerOperation(Summary = "Add a new catalog")]
    [SwaggerResponse(200, "Catalog added successfully")]
    public ActionResult Add(AddCatalogDto addCatalogDto)
    {
        var catalog = new Catalog()
        {
            Name = addCatalogDto.Name,
            Desc = addCatalogDto.Desc
        };

        unitOfWork.CatalogRepo.Insert(catalog);
        unitOfWork.Save();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Edit an existing catalog")]
    [SwaggerResponse(200, "Catalog updated successfully")]
    [SwaggerResponse(404, "Catalog not found")]
    public ActionResult Edit(int id, EditCatalogDto editCatalogDto)
    {
        var catalog = unitOfWork.CatalogRepo.GetById(id);
        if (catalog == null) return NotFound();

        catalog.Name = editCatalogDto.Name;
        catalog.Desc = editCatalogDto.Desc;

        unitOfWork.CatalogRepo.Update(catalog);
        unitOfWork.Save();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a catalog")]
    [SwaggerResponse(200, "Catalog deleted successfully")]
    [SwaggerResponse(404, "Catalog not found")]
    public ActionResult Delete(int id)
    {
        var catalog = unitOfWork.CatalogRepo.GetById(id);
        if (catalog == null) return NotFound();

        unitOfWork.CatalogRepo.Delete(catalog.Id);
        unitOfWork.Save();

        return Ok();
    }
}
