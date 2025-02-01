using BookTrackApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookTrackApi.DTOs.Review
{
    public class ReviewRequest
    {
        public ReviewType Type { get; set; }
        public string Comment { get; set; }
        [Range(0, 5)] public decimal? Rating { get; set; }
    }
}
