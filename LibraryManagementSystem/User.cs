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

        public User(string name)
        {
            Name = name;
        }

        public void BorrowBook(Library library, int bookId)
        {
            library.BorrowBook(bookId, this);
        }

        public void ReturnBook(Library library, int bookId)
        {
             library.ReturnBook(bookId,this);
        }
    }
}

