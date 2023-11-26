using LibraryWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApi.Dtos.Responses
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
