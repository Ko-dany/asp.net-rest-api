using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IUnitOfWork _context;

        public BooksController(IUnitOfWork context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _context.Books.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetBookById(int id)
        {
            var book = _context.Books.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (book == null) return BadRequest();
            _context.Books.AddBook(book);
            _context.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book book)
        {
            var existingBook = _context.Books.GetBookById(book.Id);
            if (existingBook == null) return NotFound();

            if (id != book.Id) return BadRequest("Id mismatch");

            _context.Books.UpdateBook(existingBook, book);
            _context.Complete();
            return Ok();
        }

        /* 6. Delete the employee by id */
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var existingBook = _context.Books.GetBookById(id);
            if (existingBook == null) return NotFound();
            _context.Books.DeleteBook(existingBook);
            _context.Complete();
            return Ok();
        }
    }
}
