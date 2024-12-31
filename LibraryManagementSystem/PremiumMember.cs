namespace LibraryManagementSystem
{
    class PremiumMember : Member
{
    public int ExtraBooksLimit { get; set; }

    public PremiumMember(string name, string memberID) : base(name, memberID)
    {
        ExtraBooksLimit = 2; // Premium members can borrow 2 extra books
    }

    public override bool BorrowBook(Book book)
    {
        if (BorrowedBooks.Count >= 3 + ExtraBooksLimit)
        {
            Console.WriteLine("Cannot borrow more than allowed books.");
            return false;
        }
        return base.BorrowBook(book);
    }
}

}