using BookTrackApi.Data;
using BookTrackApi.Interface;
using BookTrackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTrackApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //public Task<List<Book>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<List<Book>> GetAllAsync()
        {
            return _context.Books.ToListAsync();
        }
        
    }
}
