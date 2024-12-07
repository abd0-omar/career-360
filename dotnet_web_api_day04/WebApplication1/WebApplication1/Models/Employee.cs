using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Employee
{
    public int Id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public decimal salary { get; set; }
    public string password { get; set; }
    [NotMapped]
    public string confirm_password { get; set; }
    public string email { get; set; }
    public DateOnly date { get; set; }
    public string photo { get; set; }
}