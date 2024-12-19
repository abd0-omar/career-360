using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Customer;

public class AddCustomerDto
{
    public required string Name { get; set; }
    public required string UserName { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Address { get; set; }
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Not a valid email")]
    public required string Email { get; set; }
    public required string Password { get; set; }
}