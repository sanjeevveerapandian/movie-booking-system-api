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

    Task<Booking?> GetByIdAsync(
        long bookingId);

    Task<List<Booking>> GetByUserIdAsync(
    long userId);

    Task<int> GetTotalBookingsAsync();

    Task<decimal> GetTotalRevenueAsync();

    Task<int> GetCountByTheaterIdsAsync(
    List<long> theaterIds);

    Task<decimal> GetRevenueByTheaterIdsAsync(
        List<long> theaterIds);
}