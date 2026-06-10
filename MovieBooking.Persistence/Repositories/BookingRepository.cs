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
}