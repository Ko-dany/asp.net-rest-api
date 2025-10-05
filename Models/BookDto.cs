namespace Assignment2.Models
{
    /* BookDto is used for API v1 */
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
