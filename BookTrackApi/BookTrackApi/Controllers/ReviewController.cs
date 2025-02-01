// Controllers/ReviewsController.cs
using BookTrackApi.Data;
using BookTrackApi.DTOs.Review;
using BookTrackApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

[Route("api/books/{bookId}/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public ReviewsController(ApplicationDBContext context)
    {
        _context = context;
    }

    // POST: api/books/5/reviews (for both reviews and comments)
    [HttpPost]
    //[Authorize]
    public async Task<ActionResult<Review>> CreateReviewOrComment(
        int bookId,
        [FromBody] ReviewRequest request
    )
    {
        var review = new Review
        {
            BookId = bookId,
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Comment = request.Comment,
            Rating = request.Type == ReviewType.Review ? request.Rating : null,
            Type = request.Type,
            ReviewDate = DateTime.UtcNow
        };

        // Validate review-specific rules
        if (review.Type == ReviewType.Review && !review.Rating.HasValue)
        {
            return BadRequest("Rating is required for reviews");
        }

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        if (review.Type == ReviewType.Review)
        {
            await UpdateBookRating(bookId);
        }

        return CreatedAtAction(nameof(GetReviews), new { id = review.Id }, review);
    }

    // GET: api/books/5/reviews?type=Review (or Comment)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews(
        int bookId,
        [FromQuery] ReviewType? type = null
    )
    {
        var query = _context.Reviews
            .Where(r => r.BookId == bookId)
            .Include(r => r.User)
            .OrderByDescending(r => r.ReviewDate);

        if (type.HasValue)
        {
            query = (IOrderedQueryable<Review>)query.Where(r => r.Type == type.Value);
        }

        return await query.ToListAsync();
    }

    private async Task UpdateBookRating(int bookId)
    {
        var book = await _context.Books
            .Include(b => b.Review)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book?.Review?.Any(r => r.Type == ReviewType.Review) == true)
        {
            book.Rating = (decimal)book.Review
                .Where(r => r.Type == ReviewType.Review)
                .Average(r => r.Rating);
            await _context.SaveChangesAsync();
        }
    }
}