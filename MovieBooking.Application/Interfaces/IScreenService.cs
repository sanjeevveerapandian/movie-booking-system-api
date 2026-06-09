using MovieBooking.Application.DTOs.Screen;

namespace MovieBooking.Application.Interfaces;

public interface IScreenService
{
    Task<ScreenResponseDto> CreateAsync(
        CreateScreenDto request);

    Task<List<ScreenResponseDto>> GetAllAsync();
}