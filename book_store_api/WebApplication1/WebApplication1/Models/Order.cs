using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Order
{
    public int Id { get; set; }
    [ForeignKey("Customer")]
    [Required]
    public required string CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public Status Status { get; set; }
    
    public virtual Customer Customer { get; set; }
    public virtual List<OrderDetails> OrderDetailsList { get; set; } = new List<OrderDetails>();
}

// it will appear as int in the db
// to make it string
// change it in onModelCreating
public enum Status
{
    Pending,
    Delivered,
    Cancelled
}