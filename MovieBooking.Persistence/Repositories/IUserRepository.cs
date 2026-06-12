using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<User> CreateAsync(User user);

    Task<List<User>> GetTheaterAdminsAsync();

    Task<int> GetTotalUsersAsync();
}