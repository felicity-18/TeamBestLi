using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            User user = new User("Benjamin");

            while (true)
            {
                Console.WriteLine("Library Management System"); // A welcome menu-interface
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddBook(library);
                            break;
                        case "2":
                            BorrowBook(library, user);
                            break;
                        case "3":
                            ReturnBook(library, user);
                            break;
                        case "4":
                            library.ViewAllBooks();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("\nInvalid choice. Please select again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn error occurred: {ex.Message}");
                }
            }
        }

        static void AddBook(Library library)
        {
            Console.Write("\nEnter Title: ");
            string title = Console.ReadLine();
            Console.Write("\nEnter Author: ");
            string author = Console.ReadLine();
            Console.Write("\nEnter ISBN: ");
            string isbn = Console.ReadLine();

            Book book = new Book(title, author, isbn, 0);
            library.AddBook(book);
        }

        static void BorrowBook(Library library, User user)
        {
            Console.Write("\nEnter book ID: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                user.BorrowBook(library, bookId);
            }
            else
            {
                Console.WriteLine("\nInvalid book ID.");
            }
        }

        static void ReturnBook(Library library, User user)
        {
            Console.Write("\nEnter book ID: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                user.ReturnBook(library, bookId);
            }
            else
            {
                Console.WriteLine("\nInvalid book ID.");
            }
        }
    }
}