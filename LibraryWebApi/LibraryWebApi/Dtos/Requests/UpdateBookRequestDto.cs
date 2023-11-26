using LibraryWebApi.Dtos.Responses;

namespace LibraryWebApi.Dtos.Requests
{
    public class UpdateBookRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
