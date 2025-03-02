using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackApi.Data;
using BookTrackApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookTrackApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDBContext _context;
        public ReviewRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task GetAll()
        {
            return await _context.Reviews.ToListAsync();
        ;
        }
    }
}