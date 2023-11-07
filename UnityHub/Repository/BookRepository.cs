using Microsoft.EntityFrameworkCore;
using UnityHub.Model;

namespace UnityHub.Repository
{
    public class BookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Book.Include(b => b.Author).ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Book.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Book.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Book.Find(id);

            if (book != null)
            {
                _context.Book.Remove(book);
                _context.SaveChanges();
            }
        }
    }

}
