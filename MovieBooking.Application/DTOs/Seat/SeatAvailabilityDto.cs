namespace MovieBooking.Application.DTOs.Seat;

public class SeatAvailabilityDto
{
    public long SeatId { get; set; }

    public string SeatNumber { get; set; } = string.Empty;

    public string SeatType { get; set; } = string.Empty;

    public bool IsBooked { get; set; }
}