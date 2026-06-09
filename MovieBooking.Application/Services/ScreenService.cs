using MovieBooking.Application.DTOs.Screen;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class ScreenService : IScreenService
{
    private readonly IScreenRepository _screenRepository;

    public ScreenService(
        IScreenRepository screenRepository)
    {
        _screenRepository = screenRepository;
    }

    public async Task<ScreenResponseDto> CreateAsync(
        CreateScreenDto request)
    {
        var screen = new Screen
        {
            TheaterId = request.TheaterId,
            Name = request.Name,
            Capacity = request.Capacity,
            IsActive = true
        };

        await _screenRepository.CreateAsync(screen);

        return new ScreenResponseDto
        {
            Id = screen.Id,
            TheaterId = screen.TheaterId,
            Name = screen.Name,
            Capacity = screen.Capacity,
            IsActive = screen.IsActive
        };
    }

    public async Task<List<ScreenResponseDto>> GetAllAsync()
    {
        var screens =
            await _screenRepository.GetAllAsync();

        return screens.Select(x =>
            new ScreenResponseDto
            {
                Id = x.Id,
                TheaterId = x.TheaterId,
                Name = x.Name,
                Capacity = x.Capacity,
                IsActive = x.IsActive
            }).ToList();
    }
}