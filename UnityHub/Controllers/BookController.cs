using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UnityHub.Controllers.DTO;
using UnityHub.Service;

namespace UnityHub.Controllers
{
    // Route for this controller: api/books
    [Route("api/books")]

    // ApiController attribute ensures automatic model validation and binding from the request body
    [ApiController]

    // Enable CORS to allow cross-origin requests (replace "AllowAll" with your actual CORS policy)
    [EnableCors("AllowAll")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        // Constructor injection of BookService
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            // Retrieve all books from the BookService
            var books = _bookService.GetAllBooks();

            // Return a 200 OK status with the list of books in the response body
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            // Retrieve a specific book by its ID from the BookService
            var book = _bookService.GetBookById(id);

            // Check if the book is not found and return a 404 Not Found status if needed
            if (book == null)
            {
                return NotFound();
            }

            // Return a 200 OK status with the requested book in the response body
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDto)
        {
            // Add a new book using data from the request body to the BookService
            _bookService.AddBook(bookDto);

            // Return a 201 Created status with the location of the new resource in the response headers
            return CreatedAtAction(nameof(GetBookById), new { id = bookDto.Id }, bookDto);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
            // Update an existing book by its ID using data from the request body in the BookService
            _bookService.UpdateBook(id, bookDto);

            // Return a 204 No Content status
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // Delete a specific book by its ID from the BookService
            _bookService.DeleteBook(id);

            // Return a 204 No Content status
            return NoContent();
        }
    }
}
