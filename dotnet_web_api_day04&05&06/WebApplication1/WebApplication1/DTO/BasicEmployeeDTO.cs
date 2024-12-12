using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.DTO;

public class BasicEmployeeDTO
{
     public string name { get; set; }
     public string username { get; set; }
     public decimal salary { get; set; }
     public string password { get; set; }
     public string email { get; set; }
     public DateOnly date { get; set; }
     public string photo { get; set; }
}