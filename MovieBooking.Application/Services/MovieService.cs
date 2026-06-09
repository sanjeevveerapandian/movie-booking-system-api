using MovieBooking.Application.DTOs.Movie;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieResponseDto> CreateAsync(CreateMovieDto dto)
    {
        var movie = new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            DurationMinutes = dto.DurationMinutes,
            Genre = dto.Genre,
            Language = dto.Language,
            PosterUrl = dto.PosterUrl,
            ReleaseDate = dto.ReleaseDate,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await _movieRepository.CreateAsync(movie);

        return new MovieResponseDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre,
            Language = movie.Language,
            PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            IsActive = movie.IsActive
        };
    }

    public async Task<List<MovieResponseDto>> GetAllAsync()
    {
        var movies = await _movieRepository.GetAllAsync();

        return movies.Select(movie => new MovieResponseDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre,
            Language = movie.Language,
            PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            IsActive = movie.IsActive
        }).ToList();
    }

    public async Task<MovieResponseDto?> GetByIdAsync(long id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
            return null;

        return new MovieResponseDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            DurationMinutes = movie.DurationMinutes,
            Genre = movie.Genre,
            Language = movie.Language,
            PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            IsActive = movie.IsActive
        };
    }
}