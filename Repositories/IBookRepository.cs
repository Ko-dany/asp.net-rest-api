using Assignment2.Models;

namespace Assignment2.Repositories
{
    public interface IBookRepository
    {
        /* Version 1.0 */
        IEnumerable<BookDto> GetAllBookDto();
        BookDto GetBookDto(Book book);
        void AddBookDto(BookDto book);
        void UpdateBookDto(Book existingBook, BookDto book);

        /* Version 2.0 */
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book existingBook, Book book);
        void DeleteBook(Book existingBook);
    }
}
