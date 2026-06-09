using MovieBooking.Application.DTOs.Theater;

namespace MovieBooking.Application.Interfaces;

public interface ITheaterService
{
    Task<TheaterResponseDto> CreateAsync(
        long ownerId,
        CreateTheaterDto request);

    Task<List<TheaterResponseDto>> GetAllAsync();
}