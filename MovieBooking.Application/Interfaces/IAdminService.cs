using MovieBooking.Application.DTOs.Admin;

namespace MovieBooking.Application.Interfaces;

public interface IAdminService
{
    Task CreateTheaterAdminAsync(
        CreateTheaterAdminDto dto);
}