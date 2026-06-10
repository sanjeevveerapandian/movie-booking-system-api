using MovieBooking.Application.DTOs.Seat;

namespace MovieBooking.Application.Interfaces;

public interface ISeatService
{
    Task<List<SeatAvailabilityDto>>
        GetAvailableSeatsAsync(
            long showId,
            long screenId);
}