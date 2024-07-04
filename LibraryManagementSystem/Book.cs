using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool IsBorrowed { get; set; }
        public int BookId { get; private set; }

        public Book(string title, string author, string isbn, int bookId)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
            BookId = bookId;
        }

        public override string ToString()
        {
            return $"'{Title}' by {Author} (ISBN: {ISBN}, ID: {BookId}, Borrowed: {IsBorrowed})";
        }
    }
}
