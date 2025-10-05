using Asp.Versioning;
using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IUnitOfWork _context;

        public BooksController(IUnitOfWork context)
        {
            _context = context;
        }

        /* Version 1.0 */
        [MapToApiVersion("1.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooksV1()
        {
            var books = _context.Books.GetAllBookDto();
            return Ok(books);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetBookByIdV1(int id)
        {
            var book = _context.Books.GetBookById(id);
            if (book == null) return NotFound();

            var result = _context.Books.GetBookDto(book);
            return Ok(result);
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public ActionResult AddBookV1(BookDto book)
        {
            if (book == null) return BadRequest();

            _context.Books.AddBookDto(book);
            _context.Complete();
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public ActionResult UpdateBookV1(int id, BookDto book)
        {
            var existingBook = _context.Books.GetBookById(book.Id);
            if (existingBook == null) return NotFound();

            if (id != book.Id) return BadRequest("Id mismatch");

            _context.Books.UpdateBookDto(existingBook, book);
            _context.Complete();
            return Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public ActionResult DeleteBookV1(int id)
        {
            var existingBook = _context.Books.GetBookById(id);
            if (existingBook == null) return NotFound();

            _context.Books.DeleteBook(existingBook);
            _context.Complete();
            return Ok();
        }

        /* Version 2.0 */
        [MapToApiVersion("2.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooksV2()
        {
            var books = _context.Books.GetAllBooks();
            return Ok(books);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetBookByIdV2(int id)
        {
            var book = _context.Books.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public ActionResult AddBookV2(Book book)
        {
            if (book == null) return BadRequest();
            _context.Books.AddBook(book);
            _context.Complete();
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public ActionResult UpdateBookV2(int id, Book book)
        {
            var existingBook = _context.Books.GetBookById(book.Id);
            if (existingBook == null) return NotFound();

            if (id != book.Id) return BadRequest("Id mismatch");

            _context.Books.UpdateBook(existingBook, book);
            _context.Complete();
            return Ok();
        }

        [MapToApiVersion("2.0")]
        [HttpDelete("{id}")]
        public ActionResult DeleteBookV2(int id)
        {
            var existingBook = _context.Books.GetBookById(id);
            if (existingBook == null) return NotFound();
            _context.Books.DeleteBook(existingBook);
            _context.Complete();
            return Ok();
        }
    }
}
