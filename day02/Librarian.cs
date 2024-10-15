public class Librarian : LibraryUser
{
    public Librarian(string name, MemberShip membership, int id, string email)
        : base(name, membership, id, email)
    {
    }

    public void AddBooks(Library library, Book newBook)
    {
        library.AddBooks(newBook);
    }
}
