using BookTrackApi.DTOs.Book;
using BookTrackApi.Models;
using System.Runtime.CompilerServices;

namespace BookTrackApi.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Genre = book.Genre,
                Description = book.Description
            };
        }
        public static Book ToBookFromCreate (this CreateBookDto bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Year = bookDto.Year,
                Genre = bookDto.Genre,
                Description = bookDto.Description,
                DateAdded = DateTime.UtcNow
            };

        }
    }
}
