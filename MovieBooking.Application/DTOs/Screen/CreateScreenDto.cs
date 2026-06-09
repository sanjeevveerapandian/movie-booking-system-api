namespace MovieBooking.Application.DTOs.Screen;

public class CreateScreenDto
{
    public long TheaterId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; }
}