
using System.Runtime.InteropServices;

namespace LibraryManagementSystem{
    class Program
    {   
        static void Main(string[] args)
        {
            Library library = new Library();
            InitializeLibrary(library);

            while (true){
                Console.WriteLine("Welcome to Squishmallow's Library\nChoose an operation:\n\n");
                Console.WriteLine("1.- Register member");
                Console.WriteLine("2.- Add book");
                Console.WriteLine("3.- Remove Book");
                Console.WriteLine("4.- Borrow Book");
                Console.WriteLine("5.- Return Book");
                Console.WriteLine("6.- List Books");
                Console.WriteLine("7.- List Members");
                Console.WriteLine("8.- Exit");

                Console.WriteLine("Choose the OP Number\n");
                string option = Console.ReadLine();
                
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter member name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter member ID:");
                        string memberID = Console.ReadLine();
                        Member member = new Member(name, memberID);
                        library.RegisterMember(member);
                        break;

                    case "2":
                        Console.WriteLine("Enter Book name:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter author:");
                        string author = Console.ReadLine();

                        Console.WriteLine("Enter ISBN:");
                        string isbn = Console.ReadLine();
                        Book book = new Book(title, author, isbn);
                        library.AddBook(book);
                        break;
                    case "3":
                        Console.WriteLine("Enter ISBN of the book to remove:");
                        string isbnToRemove = Console.ReadLine();
                        library.RemoveBook(isbnToRemove);
                        break;
                    case "4":
                        Console.WriteLine("Enter member ID:");
                        string memberIDToBorrow = Console.ReadLine();
                        Console.WriteLine("Enter ISBN of the book to borrow:");
                        string isbnToBorrow = Console.ReadLine();
                        library.BorrowBook(memberIDToBorrow, isbnToBorrow);
                        break;
                    case "5":
                        Console.WriteLine("Enter member ID:");
                        string memberIDToReturn = Console.ReadLine();
                        Console.WriteLine("Enter ISBN of the book to return:");
                        string isbnToReturn = Console.ReadLine();
                        library.ReturnBook(memberIDToReturn, isbnToReturn);
                        break;
                    case "6":
                        library.ListBooks();
                        break;
                    case "7":
                        library.ListMembers();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;                    
                }

            }



        }
        private static void InitializeLibrary(Library library)
        {   
            Book b1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            Book b2 = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084");
            Book b3 = new Book("1984", "George Orwell", "9780451524935");
            Book b4 = new Book("Pride and Prejudice", "Jane Austen", "9780141439518");
            Book b5 = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
            Book b6 = new Book("Animal Farm", "George Orwell", "9780451526342");
            Book b7 = new Book("Brave New World", "Aldous Huxley", "9780060850524");
            Book b8 = new Book("The Lord of the Rings", "J.R.R. Tolkien", "9780618640157");
            Book b9 = new Book("The Hobbit", "J.R.R. Tolkien", "9780618002214");
            Book b10 = new Book("Fahrenheit 451", "Ray Bradbury", "9781451673319");
            library.AddBook(new Book("Princesas Dragón: El fin de la magia", "Pedro Mañas", "9788491828266"));
            library.AddBook(b1);
            library.AddBook(b2);
            library.AddBook(b3);
            library.AddBook(b4);
            library.AddBook(b5);
            library.AddBook(b6);
            library.AddBook(b7);
            library.AddBook(b8);
            library.AddBook(b9);
            library.AddBook(b10);
        }

    }

}
