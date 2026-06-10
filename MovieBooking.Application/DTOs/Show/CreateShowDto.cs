namespace MovieBooking.Application.DTOs.Show;

public class CreateShowDto
{
    public long MovieId { get; set; }

    public long ScreenId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal TicketPrice { get; set; }
}