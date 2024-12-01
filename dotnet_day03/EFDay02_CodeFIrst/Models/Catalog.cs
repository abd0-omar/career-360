namespace EFDay02_CodeFIrst.Models;

public class Catalog
{
    public int id { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    // add virtual for lazy loading
    public virtual List<News> news { get; set; } = new List<News>();

    public override string ToString()
    {
        return name;
    }
}