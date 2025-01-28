namespace BookTrackApi.Models
{
    public class ReadingProgress
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PagesRead { get; set; }
        public ReadingStatus Status { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Book Book { get; set; }
    }
}
