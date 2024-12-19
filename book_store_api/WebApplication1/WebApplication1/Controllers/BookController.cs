using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.UnitOfWorks;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.DTOs.Book;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(UnitOfWork unitOfWork) : ControllerBase
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet]
    [SwaggerOperation(Summary = "Get all books")]
    [SwaggerResponse(200, "Books retrieved successfully")]
    [SwaggerResponse(404, "No books found")]
    public ActionResult GetAll()
    {
        var books = unitOfWork.BookRepo.GetAll();
        var booksDto = new List<ViewBookDto>();
        foreach (var book in books)
        {
            if (book.Author == null) continue;
            if (book.Catalog == null) continue;
            var bookDto = new ViewBookDto()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.FullName,
                CatalogName = book.Catalog.Name,
                PublishDate = book.PublishDate,
                Price = book.Price,
                Stock = book.Stock,
            };
            booksDto.Add(bookDto);
        }
        if (booksDto.Count == 0) return NotFound();
        return Ok(booksDto);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "customer, admin")]
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get a book by ID")]
    [SwaggerResponse(200, "Book retrieved successfully")]
    [SwaggerResponse(404, "Book not found")]
    public ActionResult GetById(int id)
    {
        var book = unitOfWork.BookRepo.GetById(id);
        if (book == null)
        {
            return NotFound();
        }

        if (book.Author == null) return BadRequest();
        if (book.Catalog == null) return BadRequest();
        var bookDto = new ViewBookDto()
        {
            Id = book.Id,
            Title = book.Title,
            AuthorName = book.Author.FullName,
            CatalogName = book.Catalog.Name,
            PublishDate = book.PublishDate,
            Price = book.Price,
            Stock = book.Stock
        };

        return Ok(book);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpPost]
    [SwaggerOperation(Summary = "Add a new book")]
    [SwaggerResponse(200, "Book added successfully")]
    [SwaggerResponse(400, "Invalid input")]
    public ActionResult Add(AddBookDto addBookDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var book = new Book()
        {
            Title = addBookDto.Title,
            PublishDate = addBookDto.PublishDate,
            Price = addBookDto.Price,
            Stock = addBookDto.Stock,
            AuthorId = addBookDto.AuthorId,
            CatalogId = addBookDto.CatalogId,
        };
        unitOfWork.BookRepo.Insert(book);
        unitOfWork.Save();
        return Ok(book);
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpPut]
    [SwaggerOperation(Summary = "Update an existing book")]
    [SwaggerResponse(200, "Book updated successfully")]
    [SwaggerResponse(400, "Invalid input")]
    [SwaggerResponse(404, "Book not found")]
    public ActionResult Update(EditBookDto editBookDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var book = unitOfWork.BookRepo.GetById(editBookDto.Id);
        if (book == null) return NotFound();
        book.Title = editBookDto.Title;
        book.Price = editBookDto.Price;
        book.Stock = editBookDto.Stock;
        book.PublishDate = editBookDto.PublishedDate;
        unitOfWork.BookRepo.Update(book);
        unitOfWork.Save();
        return Ok();
    }

    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a book")]
    [SwaggerResponse(204, "Book deleted successfully")]
    [SwaggerResponse(404, "Book not found")]
    public ActionResult Delete(int id)
    {
        var book = unitOfWork.BookRepo.GetById(id);
        if (book == null)
        {
            return NotFound();
        }

        unitOfWork.BookRepo.Delete(book.Id);
        unitOfWork.Save();
        return NoContent();
    }
}