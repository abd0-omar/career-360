using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("task")]
public class TodoControllerFilteringAndPriority(TodoContext db): ControllerBase
{
    [HttpGet("completed")]
    public ActionResult<List<Todo>> get_completed_todos([FromQuery] bool completed)
    {
        Status status = Status.Completed;
        if (!completed)
        {
            status = Status.Incomplete;
        }
        var todos = db.Todos.Where(todo => todo.Status == status).ToList();
        if (todos.Count == 0) return NotFound();
        return Ok(todos);
    }
    [HttpGet("due_date")]
    public ActionResult<List<Todo>> get_todos_by_due_date([FromQuery] DateTime dueDate)
    {
        var todos = db.Todos.Where(todo => todo.DueDate == dueDate).ToList();
        if (todos.Count == 0) return NotFound();
        return Ok(todos);
    }
    [HttpGet("priority")]
    public ActionResult<List<Todo>> get_todos_by_priority([FromQuery] Priority priority)
    {
        var todos = db.Todos.Where(todo => todo.Priority == priority).ToList();
        if (todos.Count == 0) return NotFound();
        return Ok(todos);
    }

    [HttpPut("{id:int}/priority")]
    public ActionResult update_todo_priority(int id, UpdateTodoPriority updateTodoPriority)
    {
        var todo = db.Todos.Find(id);
        if (todo == null) return NotFound();
        todo.Priority = updateTodoPriority.Priority;
        db.Entry(todo).State = EntityState.Modified;
        db.SaveChanges();
        return NoContent();
    }
}