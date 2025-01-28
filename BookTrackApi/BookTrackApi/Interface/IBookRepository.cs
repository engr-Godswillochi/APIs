using BookTrackApi.Models;

namespace BookTrackApi.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
    }
}
