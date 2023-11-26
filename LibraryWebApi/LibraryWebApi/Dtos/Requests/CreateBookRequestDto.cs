using LibraryWebApi.Dtos.Responses;
using LibraryWebApi.Models;

namespace LibraryWebApi.Dtos.Requests
{
    public class CreateBookRequestDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
