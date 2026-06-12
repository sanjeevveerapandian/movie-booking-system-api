namespace MovieBooking.Application.DTOs.Booking;

public class BookingHistoryDto
{
    public long BookingId { get; set; }

    public string Movie { get; set; } = string.Empty;

    public string Theater { get; set; } = string.Empty;

    public DateTime ShowTime { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = string.Empty;
}