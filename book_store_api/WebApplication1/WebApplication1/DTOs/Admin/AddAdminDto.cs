using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Admin;

public class AddAdminDto
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    public string? Phone { get; set; }
}