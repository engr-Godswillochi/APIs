using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackApi.Data;
using BookTrackApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookTrackApi.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IReviewRepository _reviewRepo;
        public ReviewController(ApplicationDBContext context, IReviewRepository reviewRepo)
        {
            _context = context;
            _reviewRepo = reviewRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reviewRepo.GetAll();
            return Ok(result);
        }
        
    }
}