using BookTrackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTrackApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(options: dbContextOptions)
        {

        }
        public DbSet<Book> books { get; set; }
        public DbSet<Collection> collections { get; set; }
        public DbSet<ReadingProgress> readingProgress { get; set; }
        public DbSet<Review> reviews { get; set; }
    }
}
