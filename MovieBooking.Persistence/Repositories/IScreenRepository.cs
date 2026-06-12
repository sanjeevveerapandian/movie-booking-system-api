using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IScreenRepository
{
    Task<Screen> CreateAsync(Screen screen);

    Task<List<Screen>> GetAllAsync();

    Task<int> GetCountByTheaterIdsAsync(
    List<long> theaterIds);
}