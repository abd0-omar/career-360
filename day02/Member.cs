public class Member : LibraryUser
{
    private const int MaxBorrowLimit = 3;
    private List<Book> borrowedBooks = new List<Book>();

    public Member(string name, MemberShip membership, int id, string email)
        : base(name, membership, id, email)
    {
    }

    public void BorrowBook(Library library, string title)
    {
        if (borrowedBooks.Count >= MaxBorrowLimit)
        {
            Console.WriteLine("Borrow limit reached.");
            return;
        }

        var book = library.GetBookByTitle(title);
        if (book != null && book.IsAvailable)
        {
            book.IsAvailable = false;
            borrowedBooks.Add(book);
            Console.WriteLine($"Borrowed {title} successfully.");
        }
        else
        {
            Console.WriteLine($"{title} is not available.");
        }
    }

    public void ReturnBook(Library library, string title)
    {
        var book = borrowedBooks.Find(b => b.Title == title);
        if (book != null)
        {
            book.IsAvailable = true;
            borrowedBooks.Remove(book);
            Console.WriteLine($"Returned {title} successfully.");
        }
        else
        {
            Console.WriteLine($"{title} was not borrowed.");
        }
    }
}
