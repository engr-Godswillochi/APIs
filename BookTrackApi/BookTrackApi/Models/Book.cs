using System.ComponentModel.DataAnnotations;

namespace BookTrackApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } =string.Empty;

        [Range(0, 5)]
        public decimal Rating { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Review>? Review { get; set; } 
        public ICollection<Collection>? Collections { get; set; }
        public ICollection<ReadingProgress>? readingProgress { get; set; }
        
    }

}
