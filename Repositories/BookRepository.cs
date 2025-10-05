using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /* Version 1.0 */
        public IEnumerable<BookDto> GetAllBookDto()
        {
            IEnumerable<Book> books = _appDbContext.Books.ToList();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price,
                IsAvailable = b.IsAvailable
            });
        }
        public BookDto GetBookDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                IsAvailable = book.IsAvailable
            };
        }
        public void AddBookDto(BookDto bookDto)
        {
            Book book = new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Price = bookDto.Price,
                IsAvailable = bookDto.IsAvailable,
                Genre = null,
                PublishedYear = null,
            };
            AddBook(book);
        }
        public void UpdateBookDto(Book existingBook, BookDto book)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.IsAvailable = book.IsAvailable;
        }

        /* Version 2.0 */
        public IEnumerable<Book> GetAllBooks() { return _appDbContext.Books.ToList(); }
        public Book GetBookById(int id) { return _appDbContext.Books.Find(id); }
        public void AddBook(Book book) { _appDbContext.Add(book); }
        public void UpdateBook(Book existingBook, Book book)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.IsAvailable = book.IsAvailable;
            existingBook.Genre = book.Genre;
            existingBook.PublishedYear = book.PublishedYear;
        }
        public void DeleteBook(Book existingBook) { _appDbContext.Remove(existingBook); }
    }
}
