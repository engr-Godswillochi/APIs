﻿using BookTrackApi.Interface;
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
    }
}
