using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books;
        public Library() 
        { 
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book SearchBook(string query)
        {
            return books.FirstOrDefault(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) || b.BookId.ToString().Equals(query) || b.Title.StartsWith(query, StringComparison.OrdinalIgnoreCase) || b.Author.StartsWith(query, StringComparison.OrdinalIgnoreCase));
        }

        public bool BorrowBook(Book book, User user)
        {
            if (book == null || book.IsBorrowed)
            {
                return false;
            }

            book.IsBorrowed = true;
            user.BorrowBook(book);
            return true;
        }

        public void ReturnBook(Book book,User user, Library library)
        {
            if (book != null && book.IsBorrowed)
            {
                book.IsBorrowed = false;
                user.ReturnBook(book);
            }
        }

        public List<Book> GetAvailableBooks()
        {
            return books.Where(b => !b.IsBorrowed).ToList();
        }

        public void ViewAllBooks()
        {
            if (books.Any())
            {
                Console.WriteLine("\nAll books: ");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No books available in the library.");
            }
        }
    }
}

