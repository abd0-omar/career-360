// will try to utilize better error handling in the next assigments
internal class Program
{
    private static void Main(string[] args)
    {
        var library = new Library();
        var librarian = new Librarian("Librarian", MemberShip.Promax, 1, "Steve@unemployedjobs.com");
        var member = new Member("Member", MemberShip.Standard, 2, "Steve_Carrel@kidslover.com");

        var book1 = new Book("ktab_7yaty", "elosta", "5521", true);
        // book so good they made a sequel
        var book2 = new Book("ktab_7yaty2", "abdo", "42069", true);

        librarian.AddBooks(library, book1);
        librarian.AddBooks(library, book2);

        library.DisplayBooks();

        member.BorrowBook(library, "ktab_7yaty");
        library.DisplayBooks();

        // didn't even borrow it to return it
        member.ReturnBook(library, "ktab_7yaty2");
        library.DisplayBooks();
    }
}
