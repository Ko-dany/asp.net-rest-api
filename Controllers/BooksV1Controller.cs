using Asp.Versioning;
using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksV1Controller : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public BooksV1Controller(IUnitOfWork context)
        {
            _context = context;
        }

        /* Version 1.0 */
        [Authorize(Roles = "User, Admin")]
        [MapToApiVersion("1.0")]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooksV1()
        {
            var books = _context.Books.GetAllBookDto();
            return Ok(books);
        }

        [Authorize(Roles = "User, Admin")]
        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetBookByIdV1(int id)
        {
            var book = _context.Books.GetBookById(id);
            if (book == null) return NotFound();

            var result = _context.Books.GetBookDto(book);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [MapToApiVersion("1.0")]
        [HttpPost]
        public ActionResult AddBookV1(BookDto book)
        {
            if (book == null) return BadRequest();

            _context.Books.AddBookDto(book);
            _context.Complete();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
    }
}
