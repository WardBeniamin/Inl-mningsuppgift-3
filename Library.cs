using Bibliotek;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Bibliotek
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }

        // Konstruktor
        public Library()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }

        // Läsa in data från JSON-fil
        public void LoadDataFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var jsonData = File.ReadAllText(filePath);
                    var data = JsonSerializer.Deserialize<LibraryData>(jsonData);
                    Books = data?.Books ?? new List<Book>();
                    Authors = data?.Authors ?? new List<Author>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading data: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("JSON file not found. Starting with empty library.");
            }
        }

        // Spara data till JSON-fil
        public void SaveDataToJson(string filePath)
        {
            var data = new LibraryData { Books = Books, Authors = Authors };
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }

        // Lägg till ny bok
        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        // Lägg till ny författare
        public void AddAuthor(Author author)
        {
            Authors.Add(author);
        }

        // Uppdatera bokdetaljer
        public void UpdateBook(int id, string newTitle, string newAuthor, string newGenre, int newYear, int newIsbn, List<int> newReview)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                book.Genre = newGenre;
                book.PublishYear = newYear;
                book.Isbn = newIsbn;
                book.Review = newReview;
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Uppdatera författardetaljer
        public void UpdateAuthor(int id, string newName, string newCountry)
        {
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                author.Name = newName;
                author.Country = newCountry;
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        // Ta bort bok
        public void RemoveBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                Books.Remove(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Ta bort författare
        public void RemoveAuthor(int id)
        {
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                Authors.Remove(author);
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        // Lista alla böcker
        public void ListAllBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in Books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Year: {book.PublishYear}, Rating: {book.CalculateAverageRating():0.0}");
                }
            }
        }

        // Lista alla författare
        public void ListAllAuthors()
        {
            if (Authors.Count == 0)
            {
                Console.WriteLine("No authors available.");
            }
            else
            {
                foreach (var author in Authors)
                {
                    Console.WriteLine($"Author: {author.Name}, Country: {author.Country}");
                }
            }
        }

        // Sök och filtrera böcker (exempel på filter: genre)
        public void SearchBooksByGenre(string genre)
        {
            var filteredBooks = Books.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filteredBooks.Any())
            {
                foreach (var book in filteredBooks)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}");
                }
            }
            else
            {
                Console.WriteLine("No books found for the given genre.");
            }
        }
    }
}
