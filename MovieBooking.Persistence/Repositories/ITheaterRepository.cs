using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface ITheaterRepository
{
    Task<Theater> CreateAsync(Theater theater);

    Task<List<Theater>> GetAllAsync();

    Task<Theater?> GetByIdAsync(long id);

    Task<int> GetTotalTheatersAsync();

    Task<List<Theater>> GetByOwnerIdAsync(
    long ownerId);
}