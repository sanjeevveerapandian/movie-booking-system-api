using MovieBooking.Application.DTOs.Movie;

namespace MovieBooking.Application.Interfaces;

public interface IMovieService
{
    Task<MovieResponseDto> CreateAsync(CreateMovieDto dto);

    Task<List<MovieResponseDto>> GetAllAsync();

    Task<MovieResponseDto?> GetByIdAsync(long id);
}