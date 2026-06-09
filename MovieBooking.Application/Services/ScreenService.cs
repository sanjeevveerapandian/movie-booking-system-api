using MovieBooking.Application.DTOs.Screen;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class ScreenService : IScreenService
{
    private readonly IScreenRepository _screenRepository;
    private readonly ISeatRepository _seatRepository;

    public ScreenService(
        IScreenRepository screenRepository,
        ISeatRepository seatRepository)
    {
        _screenRepository = screenRepository;
        _seatRepository = seatRepository;
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

        // Auto Generate Seats

        var seats = new List<Seat>();

        char row = 'A';

        int totalRows = 10;
        int seatsPerRow = screen.Capacity / totalRows;

        for (int i = 0; i < totalRows; i++)
        {
            for (int j = 1; j <= seatsPerRow; j++)
            {
                seats.Add(new Seat
                {
                    ScreenId = screen.Id,
                    SeatNumber = $"{row}{j}",
                    SeatType = "Regular"
                });
            }

            row++;
        }

        await _seatRepository.AddRangeAsync(seats);

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

        return screens
            .Select(x => new ScreenResponseDto
            {
                Id = x.Id,
                TheaterId = x.TheaterId,
                Name = x.Name,
                Capacity = x.Capacity,
                IsActive = x.IsActive
            })
            .ToList();
    }
}