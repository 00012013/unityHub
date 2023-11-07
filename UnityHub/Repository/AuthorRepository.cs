using UnityHub.Model;

namespace UnityHub.Repository
{
    public class AuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Author> GetAllAuthors()
        {
            return _context.Author.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Author.Find(authorId);
        }

        public void AddAuthor(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _context.Author.Find(authorId);
            if (author != null)
            {
                _context.Author.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
