using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("task")]
public class TodoControllerManagementAndStatus(TodoContext db): ControllerBase
{
    [HttpPost]
    public ActionResult add_todo(AddTodoDto addTodoDto)
    {
        var todo = new Todo()
        {
            Title = addTodoDto.Title,
            Desc = addTodoDto.Desc,
            CreationDate = DateTime.Now,
            Priority = addTodoDto.Priority,
            Status = addTodoDto.Status,
            Notes = addTodoDto.Notes,
            DueDate = addTodoDto.DueDate,
        };
        db.Todos.Add(todo);
        db.SaveChanges();
        return Created();
    }
    
    [HttpGet()]
    public ActionResult<List<Todo>> get_todos()
    {
        var todos = db.Todos.ToList();
        return Ok(todos);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Todo> get_todo_by_id(int id)
    {
        var todo = db.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }
    
    [HttpPut("{id:int}")]
    public ActionResult update_todo(int id, EditTodoDto editTodoDto)
    {
        var todo = db.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        if (editTodoDto.Title != null) todo.Title = editTodoDto.Title;
        todo.Desc = editTodoDto.Desc;
        todo.Priority = editTodoDto.Priority;
        todo.Status = editTodoDto.Status;
        todo.Notes = editTodoDto.Notes;
        todo.DueDate = editTodoDto.DueDate;
        db.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public ActionResult delete_todo(int id)
    {
        var todo = db.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        db.Todos.Remove(todo);
        db.SaveChanges();
        return NoContent();
    }
    
    [HttpGet("{id:int}/complete")]
    public ActionResult complete_todo(int id)
    {
        var todo = db.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.Status = Status.Completed;
        db.Todos.Entry(todo).State = EntityState.Modified;
        db.SaveChanges();
        return NoContent();
    }

    [HttpGet("{id:int}/incomplete")]
    public ActionResult incomplete_todo(int id)
    {
        var todo = db.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.Status = Status.Incomplete;
        db.Todos.Entry(todo).State = EntityState.Modified;
        db.SaveChanges();
        return NoContent();
    }
}