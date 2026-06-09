namespace MovieBooking.Application.DTOs.Movie;

public class UpdateMovieDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int? DurationMinutes { get; set; }

    public string? Genre { get; set; }

    public string? Language { get; set; }

    public string? PosterUrl { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public bool IsActive { get; set; }
}