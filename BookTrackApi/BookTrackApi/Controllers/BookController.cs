using BookTrackApi.Interface;
using Microsoft.AspNetCore.Mvc;
using BookTrackApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BookTrackApi.Data;
using System.Data.Entity;
namespace BookTrackApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        //private readonly IBookRepository _bookRepository;
        //public BookController(IBookRepository bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}
        private readonly ApplicationDBContext _context;
        public BookController(ApplicationDBContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("my-books")]
        public async Task<IActionResult> GetMyBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }
    }
}
