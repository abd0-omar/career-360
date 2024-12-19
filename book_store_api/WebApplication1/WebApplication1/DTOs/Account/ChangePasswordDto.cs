using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs.Account;

public class ChangePasswordDto
{
    [Required] public required string Id { get; set; }
    [Required] public required string Oldpassword { get; set; }
    [Required] public required string Newpassword { get; set; }

    [Required]
    [Compare("newpassword", ErrorMessage = "password not match")]
    public required string ConfirmPassword { get; set; }
}