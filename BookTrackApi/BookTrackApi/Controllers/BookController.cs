using BookTrackApi.Interface;
using Microsoft.AspNetCore.Mvc;
using BookTrackApi.Mappers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BookTrackApi.Data;
using Microsoft.EntityFrameworkCore;
using BookTrackApi.Models;
using BookTrackApi.DTOs.Book;
namespace BookTrackApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ApplicationDBContext _context;
        public BookController(ApplicationDBContext context, IBookRepository bookRepository)
        {
            _context = context;
             _bookRepository = bookRepository;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks(
        [FromQuery] string searchTerm = "",
        [FromQuery] string genre = "")
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(b => b.Genre == genre);

            var books = await query.ToListAsync();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] CreateBookDto createBookDto)
        {
            var book = createBookDto.ToBookFromCreate();

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBookById),
                new
                {
                    id = book.Id,
                },
                    book.ToBookDto()
                );
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBook([FromQuery] int Id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == Id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }
    }
}
