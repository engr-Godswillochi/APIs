using BookTrackApi.Interface;
using Microsoft.AspNetCore.Mvc;
using BookTrackApi.Mappers;
namespace BookTrackApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();
            var BookDto = books.Select(s => s.BookToDto()).ToList();

            return Ok(BookDto);
        }
    }
}
