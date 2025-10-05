using Assignment2.Models;

namespace Assignment2.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book existingBook,Book book);
        void DeleteBook(Book existingBook);
    }
}
