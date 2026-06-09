using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class ScreenRepository : IScreenRepository
{
    private readonly MovieBookingDbContext _context;

    public ScreenRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Screen> CreateAsync(Screen screen)
    {
        _context.Screens.Add(screen);

        await _context.SaveChangesAsync();

        return screen;
    }

    public async Task<List<Screen>> GetAllAsync()
    {
        return await _context.Screens.ToListAsync();
    }
}