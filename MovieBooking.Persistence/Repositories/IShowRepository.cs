using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IShowRepository
{
    Task<Show> CreateAsync(Show show);

    Task<List<Show>> GetAllAsync();

    Task<Show?> GetByIdAsync(long id);

    Task<int> GetCountByTheaterIdsAsync(
    List<long> theaterIds);
}