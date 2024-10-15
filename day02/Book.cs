public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, string isbn, bool isAvailable)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = isAvailable;
    }
}
