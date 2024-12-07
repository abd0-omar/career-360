using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.DTO;

public class AddEmployeeDTO
{
     [Required(ErrorMessage = "it's a requirement")]
     public string name { get; set; }
     [MinLength(10)]
     public string username { get; set; }
     [Range(1200, 20000)]
     public decimal salary { get; set; }
     public string password { get; set; }
     [Compare("password")]
     public string confirm_password { get; set; }
     [RegularExpression(
          "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$")]
     public string email { get; set; }
     public DateOnly date { get; set; }
     public IFormFile file { get; set; }
}