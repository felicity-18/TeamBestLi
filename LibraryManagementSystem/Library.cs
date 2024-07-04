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
        private int nextBookId;

        public Library()
        {
            books = new List<Book>();
            nextBookId = 1;
        }

        public void AddBook(Book book)
        {
            book = new Book(book.Title, book.Author, book.ISBN, nextBookId++);
            books.Add(book);
            Console.WriteLine($"Book added: {book}");
        }
                public void BorrowBook(int bookId, User user)
        {
            var book = books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                if (!book.IsBorrowed)
                {
                    book.IsBorrowed = true;
                    Console.WriteLine($"Book borrowed: {book} by {user.Name}");
                }
                else
                {
                    Console.WriteLine($"Book already borrowed: {book}");
                }
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
        public void ReturnBook(int bookId, User user)
        {
            var book = books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                if (book.IsBorrowed)
                {
                    book.IsBorrowed = false;
                    Console.WriteLine($"Book returned: {book} by {user.Name}");
                }
                else
                {
                    Console.WriteLine("This book is not currently borrowed.");
                }
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }
        public void ViewAllBooks()
        {
            if (books.Any())
            {
                Console.WriteLine("All books: ");
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