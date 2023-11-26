using LibraryWebApi.Context;
using LibraryWebApi.Exceptions;
using LibraryWebApi.Models;
using LibraryWebApi.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryWebApi.Repositories.Concrete
{
    public class BookRepository : IBookRepository
    {
        private readonly BaseDbContext _context;

        public BookRepository(BaseDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                throw new NotFoundException(id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> GetList()
        {
            return _context.Books
                    .Include(x=>x.Author)
                    .Include(x=>x.Publisher).ToList();
        }

        public Book? GetById(int id)
        {
            var book = _context.Books
                        .Include(x => x.Author)
                        .Include(x => x.Publisher)
                        .SingleOrDefault(x => x.Id == id);

            if (book == null)
                throw new NotFoundException(id);

            return book;
        }

        public void Update(Book book)
        {
            var updatedBook = _context.Books.Find(book.Id);
            if (updatedBook == null)
                throw new NotFoundException(book.Id);

            updatedBook.Author = book.Author;
            updatedBook.AuthorId = book.AuthorId;
            updatedBook.Publisher = book.Publisher;
            updatedBook.PublisherId = book.PublisherId;
            updatedBook.Price = book.Price;
            updatedBook.Title = book.Title;

            _context.SaveChanges();
        }

        public Book GetByTitle(string title)
        {
            var book = _context.Books.FirstOrDefault(x => x.Title == title);

            return book;
        }
    }
}
