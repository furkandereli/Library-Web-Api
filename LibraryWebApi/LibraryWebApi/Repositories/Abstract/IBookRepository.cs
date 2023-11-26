using LibraryWebApi.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LibraryWebApi.Repositories.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Book GetByTitle(string title);
    }
}
