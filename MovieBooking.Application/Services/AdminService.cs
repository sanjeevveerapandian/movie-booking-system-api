using BCrypt.Net;
using MovieBooking.Application.DTOs.Admin;
using MovieBooking.Application.Interfaces;
using MovieBooking.Persistence.Models;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;

    public AdminService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
}