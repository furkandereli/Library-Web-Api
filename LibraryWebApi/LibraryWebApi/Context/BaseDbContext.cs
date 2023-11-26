using LibraryWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryWebApi.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options):base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
