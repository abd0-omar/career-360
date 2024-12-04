namespace WebApplication1.DTOs;

public class DisplayCatalogDTO
{
    
    public int id { get; set; }
    public string name { get; set; }
    public string desc { get; set; }

    public List<string> productNames { get; set; } = new List<string>();
}