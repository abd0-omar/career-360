namespace WebApplication1.DTOs.Book;

public class ViewBookDto
{
        public int Id { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime PublishDate { get; set; }
    
        public required string AuthorName { get; set; }
        public required string CatalogName { get; set; }
}