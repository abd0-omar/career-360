namespace WebApplication1.Models;

public class Todo
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Desc { get; set; }
    public Status Status { get; set; }
    public Priority Priority  { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DueDate { get; set; }
    public string? Notes { get; set; }
}

public enum Status
{
    Created,
    Incomplete,
    Completed
}

public enum Priority
{
    Low,
    Medium,
    High
}
