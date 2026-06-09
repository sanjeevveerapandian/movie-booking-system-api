using MovieBooking.Persistence.Models;

namespace MovieBooking.Persistence.Repositories;

public interface IMovieRepository
{
    Task<Movie> CreateAsync(Movie movie);

    Task<List<Movie>> GetAllAsync();

    Task<Movie?> GetByIdAsync(long id);

    Task UpdateAsync(Movie movie);

    Task DeleteAsync(Movie movie);
}