using BCrypt.Net;
using MovieBooking.Application.DTOs.Admin;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly ITheaterRepository _theaterRepository;
    private readonly IBookingRepository _bookingRepository;

    public AdminService(
        IUserRepository userRepository,
        IMovieRepository movieRepository,
        ITheaterRepository theaterRepository,
        IBookingRepository bookingRepository)
    {
        _userRepository = userRepository;
        _movieRepository = movieRepository;
        _theaterRepository = theaterRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task CreateTheaterAdminAsync(
        CreateTheaterAdminDto dto)
    {
        var existingUser =
            await _userRepository
                .GetByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            throw new Exception(
                "Email already exists");
        }

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    dto.Password),

            RoleId = 2,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository
            .CreateAsync(user);
    }

    public async Task<DashboardDto>
        GetDashboardAsync()
    {
        return new DashboardDto
        {
            TotalUsers =
                await _userRepository
                    .GetTotalUsersAsync(),

            TotalMovies =
                await _movieRepository
                    .GetTotalMoviesAsync(),

            TotalTheaters =
                await _theaterRepository
                    .GetTotalTheatersAsync(),

            TotalBookings =
                await _bookingRepository
                    .GetTotalBookingsAsync(),

            TotalRevenue =
                await _bookingRepository
                    .GetTotalRevenueAsync()
        };
    }
}