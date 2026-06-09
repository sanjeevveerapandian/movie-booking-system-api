using MovieBooking.Persistence.Models;

namespace MovieBooking.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}