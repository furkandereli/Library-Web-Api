using LibraryWebApi.Context;
using LibraryWebApi.Exceptions;
using LibraryWebApi.Models;
using LibraryWebApi.Repositories.Abstract;

namespace LibraryWebApi.Repositories.Concrete
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BaseDbContext _context;

        public PublisherRepository(BaseDbContext context)
        {
            _context = context;
        }

        public void Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if(publisher == null)
                throw new NotFoundException(id);

            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetList()
        {
            return _context.Publishers.ToList();
        }

        public Publisher? GetById(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if(publisher == null)
                throw new NotFoundException(id);

            return publisher;
        }

        public void Update(Publisher publisher)
        {
            var updatePublisher = _context.Publishers.Find(publisher);
            if(updatePublisher == null)
                throw new NotFoundException(publisher.Id);

            _context.Publishers.Update(updatePublisher);
            _context.SaveChanges();
        }
    }
}
