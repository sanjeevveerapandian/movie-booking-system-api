using MovieBooking.Application.DTOs.Show;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class ShowService : IShowService
{
    private readonly IShowRepository _showRepository;

    public ShowService(
        IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<ShowResponseDto> CreateAsync(
        CreateShowDto request)
    {
        var show = new Show
        {
            MovieId = request.MovieId,
            ScreenId = request.ScreenId,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            TicketPrice = request.TicketPrice
        };

        await _showRepository.CreateAsync(show);

        return new ShowResponseDto
        {
            Id = show.Id,
            MovieId = show.MovieId,
            ScreenId = show.ScreenId,
            StartTime = show.StartTime,
            EndTime = show.EndTime,
            TicketPrice = show.TicketPrice
        };
    }

    public async Task<List<ShowResponseDto>> GetAllAsync()
    {
        var shows =
            await _showRepository.GetAllAsync();

        return shows.Select(x =>
            new ShowResponseDto
            {
                Id = x.Id,
                MovieId = x.MovieId,
                ScreenId = x.ScreenId,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                TicketPrice = x.TicketPrice
            }).ToList();
    }
}