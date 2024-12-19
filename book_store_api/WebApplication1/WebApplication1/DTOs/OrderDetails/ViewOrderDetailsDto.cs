namespace WebApplication1.DTOs.OrderDetails;

public class ViewOrderDetailsDto
{
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
}