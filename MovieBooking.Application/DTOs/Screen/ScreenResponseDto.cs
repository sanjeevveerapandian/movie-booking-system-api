namespace MovieBooking.Application.DTOs.Screen;

public class ScreenResponseDto
{
    public long Id { get; set; }

    public long TheaterId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public bool IsActive { get; set; }
}