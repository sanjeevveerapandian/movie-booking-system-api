namespace MovieBooking.Application.DTOs.Booking;

public class CreateBookingDto
{
    public long ShowId { get; set; }

    public List<long> SeatIds { get; set; } = new();
}