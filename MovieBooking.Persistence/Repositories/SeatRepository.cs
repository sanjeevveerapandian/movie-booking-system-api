using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly MovieBookingDbContext _context;

    public SeatRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(
        List<Seat> seats)
    {
        await _context.Seats.AddRangeAsync(seats);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Seat>>
        GetByScreenIdAsync(long screenId)
    {
        return await _context.Seats
            .Where(x => x.ScreenId == screenId)
            .ToListAsync();
    }

    public async Task<List<Seat>> GetByIdsAsync(
    List<long> seatIds)
    {
        return await _context.Seats
            .Where(x => seatIds.Contains(x.Id))
            .ToListAsync();
    }
}