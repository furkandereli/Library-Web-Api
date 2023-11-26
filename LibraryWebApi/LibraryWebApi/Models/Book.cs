using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
