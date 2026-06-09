using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface ISeatRepository
{
    Task AddRangeAsync(List<Seat> seats);

    Task<List<Seat>> GetByScreenIdAsync(long screenId);
}