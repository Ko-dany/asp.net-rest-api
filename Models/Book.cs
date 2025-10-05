using System.Reflection;

namespace Assignment2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        
        // Used in v2
        public string? Genre { get; set; }
        public int? PublishedYear { get; set; }
    }
}
