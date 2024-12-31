namespace LibraryManagementSystem
{
    class Member
    {
        public string Name { get; set; }
        public string MemberID { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public Member(string name, string memberID)
        {
            Name = name;
            MemberID = memberID;
        }

        public bool BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= 3){
                Console.WriteLine("Cannot borrow more than 3 books");
                return false;
            }

            BorrowedBooks.Add(book);
            book.IsAvailable = false;
            
            return true;
        }
        public bool ReturnBook(Book book)
        {
            if (!BorrowedBooks.Contains(book)) {
                Console.WriteLine("Book not borrowed!");
                return false;
            }
            BorrowedBooks.Remove(book);
            book.IsAvailable = true;
            return true;
        }
        public override string ToString()
        {
            string borrowdBooksList = string.Join(", ", BorrowedBooks.Select(b => b.Title));
            return $"Name: {Name}\nMemberID: {MemberID}\nBorrowed Books: [{borrowdBooksList}]\n";
        }
        
    }
}