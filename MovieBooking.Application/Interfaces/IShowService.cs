using MovieBooking.Application.DTOs.Show;

namespace MovieBooking.Application.Interfaces;

public interface IShowService
{
    Task<ShowResponseDto> CreateAsync(
        CreateShowDto request);

    Task<List<ShowResponseDto>> GetAllAsync();
}