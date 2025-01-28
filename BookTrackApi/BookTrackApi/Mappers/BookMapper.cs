using BookTrackApi.DTOs.Book;
using System.Runtime.CompilerServices;

namespace BookTrackApi.Mappers
{
    public static class BookMapper
    {
        public static BookDto BookToDto(this BookDto bookDto)
        {
            return new BookDto
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Year = bookDto.Year,
                Genre = bookDto.Genre,
                Description = bookDto.Description
            };
        }
        public static CreateBookDto ToBookFromCreate (this CreateBookDto bookDto)
        {
            return new CreateBookDto
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Year = bookDto.Year,
                Genre = bookDto.Genre,
                Description = bookDto.Description
            };
        }
    }
}
