using UnityHub.Controllers.DTO;
using UnityHub.Model;
using UnityHub.Repository;

namespace UnityHub.Service
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        public AuthorService(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        internal void AddAuthor(AuthorDTO authorDto)
        {
            Author author = new Author();
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;
            author.Age = authorDto.Age;
            _authorRepository.AddAuthor(author);
        }

        internal void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }

        internal object GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        internal object GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }

        internal void UpdateAuthor(int id, AuthorDTO authorDto)
        {
            Author existingAuthor = _authorRepository.GetAuthorById(id);

            if (existingAuthor == null)
            {
                throw new ArgumentException($"Author with ID {authorDto.Id} not found.");
            }

            existingAuthor.FirstName = authorDto.FirstName;
            existingAuthor.LastName = authorDto.LastName;
            existingAuthor.Age = authorDto.Age;

            _authorRepository.UpdateAuthor(existingAuthor);
        }
    }
}
