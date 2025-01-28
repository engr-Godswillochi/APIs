namespace BookTrackApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Rating  { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public Book Book { get; set; }
    }
}
