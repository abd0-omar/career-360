using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public class Customer: IdentityUser
{
    public string? Name { get; set; }
    public required string? Address { get; set; }
}