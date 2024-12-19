using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class OrderDetails
{
    // make it composite in OnModelCreating in context file
    [ForeignKey("order")]
    public int OrderId { get; set; }
    [ForeignKey("book")]
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public virtual Order? Order { get; set; }
    public virtual Book? Book { get; set; }
}