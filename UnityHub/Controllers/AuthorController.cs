using Microsoft.AspNetCore.Mvc;
using UnityHub.Controllers.DTO;
using UnityHub.Service;

namespace UnityHub.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            this._authorService = authorService;
        }

        // GET: api/authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            // Retrieve all authors from the service
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            // Retrieve an author by id from the service
            var author = _authorService.GetAuthorById(id);

            // Check if the author is not found
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDTO authorDto)
        {
            // Add a new author using data from the request body
            _authorService.AddAuthor(authorDto);

            // Return a 201 Created status with the location of the new resource
            return CreatedAtAction(nameof(GetAuthorById), new { id = authorDto.Id }, authorDto);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorDTO authorDto)
        {
            // Update an existing author using data from the request body
            _authorService.UpdateAuthor(id, authorDto);

            // Return a 204 No Content status
            return NoContent();
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            // Delete an author by id
            _authorService.DeleteAuthor(id);

            // Return a 204 No Content status
            return NoContent();
        }
    }
}
