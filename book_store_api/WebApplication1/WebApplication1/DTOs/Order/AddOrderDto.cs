using System.ComponentModel.DataAnnotations;
using WebApplication1.DTOs.OrderDetails;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Order;

public class AddOrderDto
{
    [Required]
    public required string CustomerId { get; set; }
    public Status Status { get; set; }

    public List<AddOrderDetailsDto> Books { get; set; } = new List<AddOrderDetailsDto>();
}