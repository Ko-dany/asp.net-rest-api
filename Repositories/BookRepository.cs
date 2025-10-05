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

        public IEnumerable<Book> GetAllBooks()
        {
            return _appDbContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _appDbContext.Books.Find(id);
        }

        public void AddBook(Book book)
        {
            _appDbContext.Add(book);
        }

        public void UpdateBook(Book existingBook, Book book)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.IsAvailable = book.IsAvailable;
        }
        public void DeleteBook(Book existingBook)
        {
            _appDbContext.Remove(existingBook);
        }
    }
}
