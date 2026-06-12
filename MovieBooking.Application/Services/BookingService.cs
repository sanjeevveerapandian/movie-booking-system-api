using MovieBooking.Application.DTOs.Booking;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IShowRepository _showRepository;
    private readonly ISeatRepository _seatRepository;

    public BookingService(
        IBookingRepository bookingRepository,
        IShowRepository showRepository,
        ISeatRepository seatRepository)
    {
        _bookingRepository = bookingRepository;
        _showRepository = showRepository;
        _seatRepository = seatRepository;
    }

    public async Task<BookingResponseDto> CreateAsync(
        long userId,
        CreateBookingDto request)
    {
        var show =
            await _showRepository.GetByIdAsync(
                request.ShowId);

        if (show == null)
        {
            throw new Exception("Show not found");
        }

        foreach (var seatId in request.SeatIds)
        {
            var booked =
                await _bookingRepository
                    .IsSeatBookedAsync(
                        request.ShowId,
                        seatId);

            if (booked)
            {
                throw new Exception(
                    $"Seat {seatId} already booked");
            }
        }

        var seats =
            await _seatRepository
                .GetByIdsAsync(
                    request.SeatIds);

        var totalAmount =
            show.TicketPrice * seats.Count;

        var booking = new Booking
        {
            UserId = userId,
            ShowId = request.ShowId,
            BookingDate = DateTime.UtcNow,
            TotalAmount = totalAmount,
            BookingStatus = "Confirmed"
        };

        await _bookingRepository.CreateAsync(
            booking);

        var bookingSeats =
    request.SeatIds
        .Select(seatId =>
            new BookingSeat
            {
                BookingId = booking.Id,
                SeatId = seatId
            })
        .ToList();

        await _bookingRepository
            .AddBookingSeatsAsync(
                bookingSeats);

        return new BookingResponseDto
        {
            BookingId = booking.Id,
            TotalAmount = booking.TotalAmount,
            BookingStatus = booking.BookingStatus
        };
    }

    public async Task<BookingDetailsDto?>
    GetByIdAsync(long bookingId)
    {
        var booking =
            await _bookingRepository
                .GetByIdAsync(bookingId);

        if (booking == null)
            return null;

        return new BookingDetailsDto
        {
            BookingId = booking.Id,

            Movie =
                booking.Show.Movie.Title,

            Theater =
                booking.Show.Screen
                    .Theater.Name,

            Screen =
                booking.Show.Screen.Name,

            ShowTime =
                booking.Show.StartTime,

            Amount =
                booking.TotalAmount,

            Seats =
                booking.BookingSeats
                    .Select(x =>
                        x.Seat.SeatNumber)
                    .ToList()
        };
    }

    public async Task<List<BookingHistoryDto>>
    GetMyBookingsAsync(
        long userId)
    {
        var bookings =
            await _bookingRepository
                .GetByUserIdAsync(userId);

        return bookings
            .Select(x =>
                new BookingHistoryDto
                {
                    BookingId = x.Id,

                    Movie =
                        x.Show.Movie.Title,

                    Theater =
                        x.Show.Screen
                            .Theater.Name,

                    ShowTime =
                        x.Show.StartTime,

                    Amount =
                        x.TotalAmount,

                    Status =
                        x.BookingStatus
                })
            .ToList();
    }


}