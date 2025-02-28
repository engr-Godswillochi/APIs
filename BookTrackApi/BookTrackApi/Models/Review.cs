
using System.ComponentModel.DataAnnotations;

namespace BookTrackApi.Models
{
    public enum ReviewType
    {
        Review,  
        Comment  
    }

    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Range(0, 5)]
        public decimal? Rating { get; set; }  

        [Required]
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public ReviewType Type { get; set; } = ReviewType.Comment;

        public Book Book { get; set; }
    }
}