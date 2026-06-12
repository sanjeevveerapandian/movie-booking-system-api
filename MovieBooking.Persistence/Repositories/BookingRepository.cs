using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly MovieBookingDbContext _context;

    public BookingRepository(
        MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> CreateAsync(
        Booking booking)
    {
        _context.Bookings.Add(booking);

        await _context.SaveChangesAsync();

        return booking;
    }

    public async Task<bool> IsSeatBookedAsync(
        long showId,
        long seatId)
    {
        return await _context.BookingSeats
            .Include(x => x.Booking)
            .AnyAsync(x =>
                x.SeatId == seatId &&
                x.Booking.ShowId == showId &&
                x.Booking.BookingStatus == "Confirmed");
    }

    public async Task<List<long>> GetBookedSeatIdsAsync(
    long showId)
    {
        return await _context.BookingSeats
            .Include(x => x.Booking)
            .Where(x =>
                x.Booking.ShowId == showId &&
                x.Booking.BookingStatus == "Confirmed")
            .Select(x => x.SeatId)
            .ToListAsync();
    }

    public async Task AddBookingSeatsAsync(
    List<BookingSeat> bookingSeats)
    {
        await _context.BookingSeats
            .AddRangeAsync(bookingSeats);

        await _context.SaveChangesAsync();
    }

    public async Task<Booking?> GetByIdAsync(
    long bookingId)
    {
        return await _context.Bookings

            .Include(x => x.User)

            .Include(x => x.Show)
                .ThenInclude(x => x.Movie)

            .Include(x => x.Show)
                .ThenInclude(x => x.Screen)
                    .ThenInclude(x => x.Theater)

            .Include(x => x.BookingSeats)
                .ThenInclude(x => x.Seat)

            .FirstOrDefaultAsync(
                x => x.Id == bookingId);
    }

    public async Task<List<Booking>>
    GetByUserIdAsync(long userId)
    {
        return await _context.Bookings

            .Include(x => x.Show)
                .ThenInclude(x => x.Movie)

            .Include(x => x.Show)
                .ThenInclude(x => x.Screen)
                    .ThenInclude(x => x.Theater)

            .Where(x => x.UserId == userId)

            .OrderByDescending(
                x => x.BookingDate)

            .ToListAsync();
    }

    public async Task<int> GetTotalBookingsAsync()
    {
        return await _context.Bookings.CountAsync();
    }

    public async Task<decimal> GetTotalRevenueAsync()
    {
        return await _context.Bookings
            .SumAsync(x => x.TotalAmount);
    }

    public async Task<int>
    GetCountByTheaterIdsAsync(
        List<long> theaterIds)
    {
        return await _context.Bookings

            .Include(x => x.Show)
                .ThenInclude(x => x.Screen)

            .CountAsync(x =>
                theaterIds.Contains(
                    x.Show.Screen.TheaterId));
    }

    public async Task<decimal>
        GetRevenueByTheaterIdsAsync(
            List<long> theaterIds)
    {
        return await _context.Bookings

            .Include(x => x.Show)
                .ThenInclude(x => x.Screen)

            .Where(x =>
                theaterIds.Contains(
                    x.Show.Screen.TheaterId))

            .SumAsync(x => x.TotalAmount);
    }
}