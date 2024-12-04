using System.Text.Json.Serialization;

namespace Bibliotek
{
    // Klass för Bok
    public class Book
    {
        // Egenskaper för boken
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("PublishYear")]
        public int PublishYear { get; set; }

        [JsonPropertyName("Genre")]
        public string Genre { get; set; }

        [JsonPropertyName("Isbn")]
        public int Isbn { get; set; }

        [JsonPropertyName("Review")]
        public List<int> Review { get; set; } // List of reviews (ratings)

        // Konstruktor för att skapa en bok
        public Book(string title, string author, string genre, int publishYear, int isbn, List<int> review = null)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublishYear = publishYear;
            Isbn = isbn;
            Review = review ?? new List<int>(); // Default if no review is provided
        }

        // Beräknar medelbetyg för boken
        public double CalculateAverageRating()
        {
            if (Review.Count == 0) return 0;
            return Review.Average();
        }
    }
}
