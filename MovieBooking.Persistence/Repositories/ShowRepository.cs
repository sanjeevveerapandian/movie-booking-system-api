using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class ShowRepository : IShowRepository
{
    private readonly MovieBookingDbContext _context;

    public ShowRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Show> CreateAsync(
        Show show)
    {
        _context.Shows.Add(show);

        await _context.SaveChangesAsync();

        return show;
    }

    public async Task<List<Show>> GetAllAsync()
    {
        return await _context.Shows
            .Include(x => x.Movie)
            .Include(x => x.Screen)
            .ToListAsync();
    }

    public async Task<Show?> GetByIdAsync(long id)
    {
        return await _context.Shows
            .Include(x => x.Movie)
            .Include(x => x.Screen)
                .ThenInclude(x => x.Theater)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int>
    GetCountByTheaterIdsAsync(
        List<long> theaterIds)
    {
        return await _context.Shows
            .Include(x => x.Screen)
            .CountAsync(x =>
                theaterIds.Contains(
                    x.Screen.TheaterId));
    }
}