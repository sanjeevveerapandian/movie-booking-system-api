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
}