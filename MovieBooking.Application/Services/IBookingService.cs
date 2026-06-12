using MovieBooking.Application.DTOs.Booking;

namespace MovieBooking.Application.Interfaces;

public interface IBookingService
{
    Task<BookingResponseDto> CreateAsync(
        long userId,
        CreateBookingDto request);
    Task<BookingDetailsDto?> GetByIdAsync(
    long bookingId);

    Task<List<BookingHistoryDto>> GetMyBookingsAsync(long userId);
}