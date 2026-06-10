namespace MovieBooking.Application.DTOs.Booking;

public class BookingResponseDto
{
    public long BookingId { get; set; }

    public decimal TotalAmount { get; set; }

    public string BookingStatus { get; set; } = string.Empty;
}