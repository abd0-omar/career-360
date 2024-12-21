using WebApplication1.Models;

namespace WebApplication1.Dtos;

public class EditTodoDto
{
            public string? Title { get; set; }
            public string? Desc { get; set; }
            public Status Status { get; set; }
            public Priority Priority  { get; set; }
            public DateTime DueDate { get; set; }
            public string? Notes { get; set; }
}