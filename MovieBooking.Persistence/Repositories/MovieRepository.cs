using Microsoft.EntityFrameworkCore;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieBookingDbContext _context;

    public MovieRepository(MovieBookingDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        _context.Movies.Add(movie);

        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(long id)
    {
        return await _context.Movies
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movie movie)
    {
        _context.Movies.Remove(movie);

        await _context.SaveChangesAsync();
    }

    public async Task<int> GetTotalMoviesAsync()
    {
        return await _context.Movies.CountAsync();
    }
}