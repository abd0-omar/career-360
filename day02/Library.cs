public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBooks(Book newBook)
    {
        books.Add(newBook);
        Console.WriteLine($"Added {newBook.Title} to the library.");
    }

    public void DisplayBooks()
    {
        if (books.Count > 0)
        {
            Console.WriteLine($"BOOKS:");
            foreach (var book in books)
            {
                Console.WriteLine($"book_title: {book.Title}, it's availability {book.IsAvailable}");
            }
        }
        else
        {
            Console.WriteLine("No books available.");
        }
    }

    public Book GetBookByTitle(string title)
    {
        var book = books?.Find(book => book.Title == title);
        if (book == null)
        {
            Console.WriteLine("No book found with this title");
            return null;
        }
        return book;
    }

}
