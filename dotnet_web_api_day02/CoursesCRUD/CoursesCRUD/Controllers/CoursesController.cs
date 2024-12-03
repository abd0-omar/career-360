using CoursesCRUD.Context;
using CoursesCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesCRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : Controller
{
    private readonly CoursesContext _db = new CoursesContext();
    
    [HttpGet]
    public ActionResult<List<Course>> GetAll()
    {
        var courses = _db.Courses.ToList();
        if (courses.Count == 0) return NotFound();
        return Ok(courses);
    }

    [HttpDelete("{id}")]
    public ActionResult<List<Course>> Delete(int id)
    {
        // can I do db entry here?
        var course = _db.Courses.SingleOrDefault(c => c.Id == id);
        if (course == null)
        {
            return NotFound();
        }

        _db.Courses.Remove(course);
        _db.SaveChanges();
        // can I return "GetAll" method
        var courses = _db.Courses.ToList();
        return Ok(courses);
    }

    [HttpPut("{id}")]
    public ActionResult<List<Course>> Edit(int id, Course? course)
    {
        if (course == null) return NotFound();
        if (course.Id != id) return BadRequest();
        // not found
        _db.Entry(course).State = EntityState.Modified;
        _db.SaveChanges();
        return NoContent();
    }
    
    // insert
    [HttpPost]
    public ActionResult Post(Course? course)
    {
        if (course == null) return BadRequest();
        _db.Courses.Add(course);
        _db.SaveChanges();
        return CreatedAtAction(
        actionName: "GetById", 
        routeValues: new { id = course.Id }, 
        value: course
    );
    }
    
    // get by id
    [HttpGet("{id:int}")]
    // new url
    // [HttpGet("/api/{id}")]
    // combine url
    // [HttpGet("api/{id}")]
    public ActionResult<Course> GetById(int id)
    {
        var course = _db.Courses.SingleOrDefault(c => c.Id == id);
        if (course == null) return NotFound();
        return Ok(course);
    }

    [HttpGet("{name}")]
    public ActionResult<Course> GetByName(string name)
    {
        var course = _db.Courses.SingleOrDefault(c => c.CrsName == name);
        if (course == null) return NotFound();
        return Ok(course);
    }
}