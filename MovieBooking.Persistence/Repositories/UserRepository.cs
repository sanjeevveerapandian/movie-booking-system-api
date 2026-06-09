using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MovieBookingDbContext _context;

    public UserRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<List<User>> GetTheaterAdminsAsync()
    {
        return await _context.Users
            .Where(x => x.RoleId == 2)
            .ToListAsync();
    }
}