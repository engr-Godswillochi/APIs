using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrackApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackApi.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ReviewController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Reviews.;
        }
        
    }
}