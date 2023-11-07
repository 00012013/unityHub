using UnityHub.Controllers.DTO;
using UnityHub.Model;
using UnityHub.Repository;

namespace UnityHub.Service
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public void AddBook(BookDTO bookDto)
        {
            // Map DTO to Entity and save
            var book = new Book
            {
                Title = bookDto.Title,
                PublishYear = bookDto.PublishYear,
                AuthorId = bookDto.AuthorId
            };

            _bookRepository.AddBook(book);
        }

        public void UpdateBook(int id, BookDTO bookDto)
        {
            // Get the existing book
            var existingBook = _bookRepository.GetBookById(id);

            if (existingBook == null)
            {
                // Handle not found scenario
                // You might want to throw an exception or return an appropriate response.
                throw new ArgumentException($"Book with ID {id} not found.");
            }

            // Update properties and save
            existingBook.Title = bookDto.Title;
            existingBook.PublishYear = bookDto.PublishYear;
            existingBook.AuthorId = bookDto.AuthorId;

            _bookRepository.UpdateBook(existingBook);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }

}
