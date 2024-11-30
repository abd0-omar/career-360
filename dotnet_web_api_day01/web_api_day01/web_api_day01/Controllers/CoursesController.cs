using Microsoft.AspNetCore.Mvc;

namespace web_api_day01.Controllers;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    static List<Course> courses = new List<Course>()
        {
            new Course()
            {
                id = 1,
                name = "abc",
                duration = 2
            },
            new Course()
            {
                id = 2,
                name = "wissenschaft",
                duration = 420
            },
            new Course()
            {
                id = 3,
                name = "naturlich",
                duration = -1
            }
        };
    
        [HttpGet]
        public List<Course> getall()
        {
            return courses;
        }

        [HttpGet("{id:int}")]

        public Course getbyid(int id)
        {
            return courses.Find(n=>n.id==id);
        }

        [HttpPost]
        public List<Course> add(Course s)
        {
            courses.Add(s);
            return courses;
        }
}