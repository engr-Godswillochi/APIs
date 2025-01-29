namespace BookTrackApi.Models
{
    public class ReadingProgress
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int PagesRead { get; set; }
        public ReadingStatus Status { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Book Book { get; set; }
    }
}
