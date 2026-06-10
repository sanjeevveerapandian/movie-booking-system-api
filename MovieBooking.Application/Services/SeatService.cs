using MovieBooking.Application.DTOs.Seat;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;
    private readonly IBookingRepository _bookingRepository;

    public SeatService(
        ISeatRepository seatRepository,
        IBookingRepository bookingRepository)
    {
        _seatRepository = seatRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<List<SeatAvailabilityDto>>
        GetAvailableSeatsAsync(
            long showId,
            long screenId)
    {
        var seats =
            await _seatRepository
                .GetByScreenIdAsync(screenId);

        var bookedSeatIds =
            await _bookingRepository
                .GetBookedSeatIdsAsync(showId);

        return seats
            .Select(x => new SeatAvailabilityDto
            {
                SeatId = x.Id,
                SeatNumber = x.SeatNumber,
                SeatType = x.SeatType,
                IsBooked =
                    bookedSeatIds.Contains(x.Id)
            })
            .ToList();
    }
}