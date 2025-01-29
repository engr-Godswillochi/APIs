using Microsoft.AspNetCore.Identity;

namespace BookTrackApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom user properties here (if needed)
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public ICollection<ReadingProgress> ReadingProgresses { get; set; }
    }
}