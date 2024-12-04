using Bibliotek;
using System;

namespace LibraryManagementAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            string filePath = "LibraryData.json";
            library.LoadDataFromJson(filePath);

            int choice;
            do
            {
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Add author");
                Console.WriteLine("3. Update book details");
                Console.WriteLine("4. Update author details");
                Console.WriteLine("5. Remove book");
                Console.WriteLine("6. Remove author");
                Console.WriteLine("7. Show all books and authors");
                Console.WriteLine("8. Search for book by genre");
                Console.WriteLine("9. Save and exit");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddBook(library);
                        break;
                    case 2:
                        AddAuthor(library);
                        break;
                    case 3:
                        UpdateBookDetails(library);
                        break;
                    case 4:
                        UpdateAuthorDetails(library);
                        break;
                    case 5:
                        RemoveBook(library);
                        break;
                    case 6:
                        RemoveAuthor(library);
                        break;
                    case 7:
                        ShowAllBooksAndAuthors(library);
                        break;
                    case 8:
                        SearchBooksByGenre(library);
                        break;
                    case 9:
                        library.SaveDataToJson(filePath);
                        Console.WriteLine("Data saved successfully.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 9);
        }

        static void AddBook(Library library)
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter publication year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year.");
                return;
            }

            Console.Write("Enter ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("Invalid ISBN.");
                return;
            }

            Book newBook = new Book(title, author, genre, year, isbn);
            library.AddBook(newBook);
            Console.WriteLine("Book added successfully.");
        }

        static void AddAuthor(Library library)
        {
            Console.Write("Enter author name: ");
            string name = Console.ReadLine();

            Console.Write("Enter author's country: ");
            string country = Console.ReadLine();

            Author newAuthor = new Author(name, country);
            library.AddAuthor(newAuthor);
            Console.WriteLine("Author added successfully.");
        }

        static void UpdateBookDetails(Library library)
        {
            Console.Write("Enter book ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter new title: ");
            string newTitle = Console.ReadLine();

            Console.Write("Enter new author: ");
            string newAuthor = Console.ReadLine();

            Console.Write("Enter new genre: ");
            string newGenre = Console.ReadLine();

            Console.Write("Enter new publication year: ");
            if (!int.TryParse(Console.ReadLine(), out int newYear))
            {
                Console.WriteLine("Invalid year.");
                return;
            }

            Console.Write("Enter new ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int newIsbn))
            {
                Console.WriteLine("Invalid ISBN.");
                return;
            }

            library.UpdateBook(id, newTitle, newAuthor, newGenre, newYear, newIsbn, new List<int>());
            Console.WriteLine("Book details updated successfully.");
        }

        static void UpdateAuthorDetails(Library library)
        {
            Console.Write("Enter author ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter new author name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter new country: ");
            string newCountry = Console.ReadLine();

            library.UpdateAuthor(id, newName, newCountry);
            Console.WriteLine("Author details updated successfully.");
        }

        static void RemoveBook(Library library)
        {
            Console.Write("Enter book ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            library.RemoveBook(id);
            Console.WriteLine("Book removed successfully.");
        }

        static void RemoveAuthor(Library library)
        {
            Console.Write("Enter author ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            library.RemoveAuthor(id);
            Console.WriteLine("Author removed successfully.");
        }

        static void ShowAllBooksAndAuthors(Library library)
        {
            Console.WriteLine("Books:");
            library.ListAllBooks();
            Console.WriteLine("\nAuthors:");
            library.ListAllAuthors();
        }

        static void SearchBooksByGenre(Library library)
        {
            Console.Write("Enter genre to search for: ");
            string genre = Console.ReadLine();
            library.SearchBooksByGenre(genre);
        }
    }
}
