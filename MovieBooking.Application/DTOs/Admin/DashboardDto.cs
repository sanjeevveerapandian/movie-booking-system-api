namespace MovieBooking.Application.DTOs.Admin;

public class DashboardDto
{
    public int TotalUsers { get; set; }

    public int TotalMovies { get; set; }

    public int TotalTheaters { get; set; }

    public int TotalBookings { get; set; }

    public decimal TotalRevenue { get; set; }
}