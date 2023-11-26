using LibraryWebApi.Context;
using LibraryWebApi.Exceptions;
using LibraryWebApi.Models;
using LibraryWebApi.Repositories.Abstract;

namespace LibraryWebApi.Repositories.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BaseDbContext _context;

        public AuthorRepository(BaseDbContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                throw new NotFoundException(id);

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public List<Author> GetList()
        {
            return _context.Authors.ToList();
        }

        public Author? GetById(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                throw new NotFoundException(id);

            return author;
        }

        public void Update(Author author)
        {
            var updateAuthor = _context.Authors.Find(author.Id);
            if(updateAuthor == null)
                throw new NotFoundException(author.Id);

            _context.Authors.Update(updateAuthor);
            _context.SaveChanges();
        }
    }
}
