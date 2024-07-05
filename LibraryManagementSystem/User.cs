using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagementSystem
{
    public class User
    {
        public string Name { get; private set; }
        private List<Book> borrowedBooks;
        public User(string name)
        {
            Name = name;
            borrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            borrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            borrowedBooks.Remove(book);
        }

        public List<Book> GetBorrowedBooks()
        {
            return borrowedBooks;
        }
    }
}

