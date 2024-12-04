namespace WebApplication1.Models;

public class Catalog
{

    public int Id { get; set; }
    // virtual for other objects here, and if it's a list make a new list
    // public virtual List<Department> depts = new List();
    public string Name { get; set; }
    public string Desc { get; set; }

    public virtual List<Product> Products { get; set; } = new List<Product>();
}