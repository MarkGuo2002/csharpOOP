namespace LibraryManagementSystem
{
    class Book
    {
        public string Title { get; set; }
        public string Author {get; set; }
        public string ISBN {get; set; }
        public bool IsAvailable {get; set; } = true;

        // Constructor
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nISBN: {ISBN}\nAvailable: {IsAvailable}\n";
        }

    }
}