using MovieBooking.Application.DTOs.Theater;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class TheaterService : ITheaterService
{
    private readonly ITheaterRepository _theaterRepository;

    public TheaterService(
        ITheaterRepository theaterRepository)
    {
        _theaterRepository = theaterRepository;
    }

    public async Task<TheaterResponseDto> CreateAsync(
        long ownerId,
        CreateTheaterDto request)
    {
        var theater = new Theater
        {
            Name = request.Name,
            Address = request.Address,
            City = request.City,
            State = request.State,
            OwnerId = ownerId,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await _theaterRepository.CreateAsync(theater);

        return new TheaterResponseDto
        {
            Id = theater.Id,
            Name = theater.Name,
            Address = theater.Address,
            City = theater.City,
            State = theater.State,
            IsActive = theater.IsActive
        };
    }

    public async Task<List<TheaterResponseDto>> GetAllAsync()
    {
        var theaters =
            await _theaterRepository.GetAllAsync();

        return theaters
            .Select(x => new TheaterResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                State = x.State,
                IsActive = x.IsActive
            })
            .ToList();
    }
}