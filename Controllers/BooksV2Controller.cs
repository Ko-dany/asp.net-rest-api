using Asp.Versioning;
using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksV2Controller : ControllerBase
    {
        IUnitOfWork _context;

        public BooksV2Controller(IUnitOfWork context)
        {
            _context = context;
        }

        /* Version 2.0 */
        [Authorize(Roles = "User, Admin")]
        [MapToApiVersion("2.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooksV2()
        {
            var books = _context.Books.GetAllBooks();
            return Ok(books);
        }

        [Authorize(Roles = "User, Admin")]
        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetBookByIdV2(int id)
        {
            var book = _context.Books.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [MapToApiVersion("2.0")]
        [HttpPost]
        public ActionResult AddBookV2(Book book)
        {
            if (book == null) return BadRequest();
            _context.Books.AddBook(book);
            _context.Complete();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
