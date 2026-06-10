namespace MovieBooking.Application.DTOs.Booking;

public class BookingDetailsDto
{
    public long BookingId { get; set; }

    public string Movie { get; set; } = string.Empty;

    public string Theater { get; set; } = string.Empty;

    public string Screen { get; set; } = string.Empty;

    public DateTime ShowTime { get; set; }

    public decimal Amount { get; set; }

    public List<string> Seats { get; set; }
        = new();
}