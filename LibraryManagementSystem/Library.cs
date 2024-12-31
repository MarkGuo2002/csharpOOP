using System.Formats.Asn1;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace LibraryManagementSystem
{
    class Library
    {
        List<Book> Books { get; set; } = new List<Book>();
        List<Member> Members { get; set; } = new List<Member>();
        List<string> Transactions {get; set; } = new List<string>();

        public bool AddBook(Book book)
        {
            Books.Add(book);
            return true;
        }

        public bool RemoveBook(string isbn)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ISBN == isbn)
                {
                    Books.RemoveAt(i);
                    return true;
                }
            }
            Console.WriteLine("Book not found");
            return false;

            // This is the recommended way using LINQ
            /*
            var bookToRemove = Book.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                return true
            }
            return false
            */
        }


        
        public bool RegisterMember(Member member)
        {
            // if (Members.Contains(member)) return false;  // shorthand for if without else
            if (Members.Contains(member))
            {
                Console.WriteLine("Member already registered");
                return false;
            }
            Members.Add(member);
            return true;
        }
        public bool BorrowBook(string memberID, string isbn)
        {
            // check if member registered
            var member = Members.FirstOrDefault(m => m.MemberID == memberID);
            if (member == null)
            {
                Console.WriteLine("Member not registered");
                return false;
            }

            // check if book's isbn exists in Books
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null || !book.IsAvailable)
            {
                Console.WriteLine("Book does not exist or it's not available");
                return false;
            } 

            if (member.BorrowBook(book)){
                Transactions.Add($"{member.Name} BORROWED '{book.Title}' on {DateTime.Now}");
                Console.WriteLine($"{member.Name} BORROWED '{book.Title}'.");
            }
            return true;
        }

        public bool ReturnBook(string memberID, string isbn)
        {
            // check if member registered
            var member = Members.FirstOrDefault(m => m.MemberID == memberID);
            if (member == null)
            {
                Console.WriteLine("Member not registered");
                return false;
            }

            // check if book's isbn exists in Books
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine("Book does not exist");
                return false;
            } 

            if (member.ReturnBook(book))
            {
                Transactions.Add($"{member.Name} RETURNED '{book.Title}' on {DateTime.Now}");
                Console.WriteLine($"{member.Name} RETURNED '{book.Title}'.");
            }
            return true;
        }
        public bool ListBooks()
        {
            foreach (Book b in Books)
            {
                Console.WriteLine($"Title: {b.Title}\n\tAuthor: {b.Author}\n\tISBN: {b.ISBN}\n\t Availability: {(b.IsAvailable ? "Available" : "Not Available" )}");
            }
            return true;
        }
        public bool ListMembers()
        {
            foreach (Member m in Members)
            {
                Console.WriteLine($"Name: {m.Name}\n\tMemberID: {m.MemberID}\n\tBorrowed Books: {string.Join(", ", m.BorrowedBooks.Select(b => b.Title))}");
            }
            return true;
        }

    }
}