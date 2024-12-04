using System.Text.Json.Serialization;

namespace Bibliotek
{
    // Klass för Författare
    public class Author
    {
        // Egenskaper för författaren
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        // Konstruktor för att skapa en författare
        public Author(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
