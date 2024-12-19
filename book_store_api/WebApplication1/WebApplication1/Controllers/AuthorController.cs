using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.UnitOfWorks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.DTOs._Author;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(UnitOfWork unitOfWork) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpPost]
    [SwaggerOperation(Summary = "Add a new author")]
    [SwaggerResponse(200, "Author added successfully")]
    public ActionResult Add(AddAuthorDto addAuthorDto)
    {
        var author = new Author()
        {
            FullName = addAuthorDto.FullName,
            NumOfBooks = addAuthorDto.NumOfBooks,
            Bio = addAuthorDto.Bio,
            Age = addAuthorDto.Age,
        };
        unitOfWork.AuthorRepo.Insert(author);
        unitOfWork.Save();
        return Ok();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet]
    [SwaggerOperation(Summary = "Get all authors")]
    [SwaggerResponse(200, "Authors retrieved successfully")]
    [SwaggerResponse(404, "No authors found")]
    public ActionResult<List<ViewAuthorDto>> GetAll()
    {
        var authors = unitOfWork.AuthorRepo.GetAll();
        if (authors.Count == 0)
        {
            return NotFound();
        }
        var viewAuthorsDto = new List<ViewAuthorDto>();

        foreach (var author in authors)
        {
            var viewAuthorDto = new ViewAuthorDto()
            {
                Id = author.Id,
                FullName = author.FullName,
                NumOfBooks = author.NumOfBooks,
                Bio = author.Bio,
                Age = author.Age
            };
            viewAuthorsDto.Add(viewAuthorDto);
        }
        return Ok(viewAuthorsDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get an author by ID")]
    [SwaggerResponse(200, "Author retrieved successfully")]
    [SwaggerResponse(404, "Author not found")]
    public ActionResult<Author> GetById(int id)
    {
        var author = unitOfWork.AuthorRepo.GetById(id);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edit an author")]
    [SwaggerResponse(204, "Author updated successfully")]
    [SwaggerResponse(404, "Author not found")]
    public ActionResult Edit(int id, EditAuthorDto editAuthorDto)
    {
        var author = unitOfWork.AuthorRepo.GetById(id);
        if (author == null)
        {
            return NotFound();
        }

        author.FullName = editAuthorDto.FullName;
        author.NumOfBooks = editAuthorDto.NumOfBooks;
        author.Bio = editAuthorDto.Bio;
        author.Age = editAuthorDto.Age;

        unitOfWork.AuthorRepo.Update(author);
        unitOfWork.Save();
        return NoContent();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete an author")]
    [SwaggerResponse(204, "Author deleted successfully")]
    [SwaggerResponse(404, "Author not found")]
    public ActionResult Delete(int id)
    {
        var author = unitOfWork.AuthorRepo.GetById(id);
        if (author == null)
        {
            return NotFound();
        }

        unitOfWork.AuthorRepo.Delete(author.Id);
        unitOfWork.Save();
        return NoContent();
    }
}