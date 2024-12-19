using WebApplication1.DTOs.OrderDetails;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Order;

public class ViewOrderDto
{
    public int Id { get; set; }
    public required string CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public Status Status { get; set; }

    public virtual List<ViewOrderDetailsDto> ViewOrderDetailsList { get; set; }
        = new List<ViewOrderDetailsDto>();
}