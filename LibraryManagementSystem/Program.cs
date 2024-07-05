using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            User user = new User("TeamBestLi");

            while (true)
            {
                Console.WriteLine();
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

        static void AddBook(Library library) {
            try
        {
            Console.Write("\nEnter book Title: ");
            string title = Console.ReadLine();
        Console.Write("\nEnter book Author: ");
            string author = Console.ReadLine();
        Console.Write("\nEnter book ISBN: ");
            string isbn = Console.ReadLine();
        int bookId = new Random().Next(1, 100); // Simple integer ID assigning at Random

        Book book = new Book(title, author, isbn, bookId);
        library.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }
    catch (Exception ex) { 
    Console.WriteLine($"An error occurred: {ex.Message}");
        }
}

        static void BorrowBook(Library library, User user)
        {
            try
            {
                Console.Write("\nSearch the book's Title, Author, Book ID, or initials of Title or Author to borrow ");
                string query = Console.ReadLine(); // User enters Title or Author or ID or Initials of title/author

                Book book = library.SearchBook(query);

                if (book != null && library.BorrowBook(book, user))
                {
                    Console.WriteLine("\nBook borrowed successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found or already borrowed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }
        static void ReturnBook(Library library, User user)
        {
            try
            {
                Console.Write("\nEnter book Title, author, or book ID to return: ");
                string query = Console.ReadLine();
                Book book = library.SearchBook(query);

                if (book != null)
                {
                    if (!book.IsBorrowed)
                    {
                        Console.WriteLine("Book not borrowed or already returned.");
                    }
                    else
                    {
                        library.ReturnBook(book, user, library);
                        Console.WriteLine("Book returned successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("\rBook not found.");
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured: {ex.Message}"); }
        }

        static void ViewAllBooks(Library library)
        {
            try
            {
                var availableBooks = library.GetAvailableBooks();
                Console.WriteLine("\nAvailable Books: ");
                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} \n ID: {book.BookId}");
                }
            }
            catch (Exception ex) { Console.WriteLine($"An error occured: {ex.Message}"); }
        }
    }
}
