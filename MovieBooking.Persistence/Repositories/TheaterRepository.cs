using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class TheaterRepository : ITheaterRepository
{
    private readonly MovieBookingDbContext _context;

    public TheaterRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Theater> CreateAsync(
        Theater theater)
    {
        _context.Theaters.Add(theater);

        await _context.SaveChangesAsync();

        return theater;
    }

    public async Task<List<Theater>> GetAllAsync()
    {
        return await _context.Theaters
            .ToListAsync();
    }

    public async Task<Theater?> GetByIdAsync(
        long id)
    {
        return await _context.Theaters
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}