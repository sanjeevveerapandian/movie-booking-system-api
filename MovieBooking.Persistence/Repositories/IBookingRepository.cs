using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IBookingRepository
{
    Task<Booking> CreateAsync(
        Booking booking);

    Task<bool> IsSeatBookedAsync(
        long showId,
        long seatId);

    Task<List<long>> GetBookedSeatIdsAsync(
        long showId);

    Task AddBookingSeatsAsync(
        List<BookingSeat> bookingSeats);
}