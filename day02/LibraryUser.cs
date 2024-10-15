public abstract class LibraryUser
{
    public string Name { get; private set; }
    public MemberShip Membership { get; private set; }
    public int ID { get; private set; }
    public string Email { get; private set; }

    protected LibraryUser(string name, MemberShip membership, int id, string email)
    {
        Name = name;
        Membership = membership;
        ID = id;
        Email = email;
    }
}
