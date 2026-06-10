using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieBooking.Persistence.Context;
using MovieBooking.Persistence.Repositories;

namespace MovieBooking.Persistence.Extensions;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MovieBookingDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ITheaterRepository, TheaterRepository>();
        services.AddScoped<IScreenRepository, ScreenRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IShowRepository, ShowRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();


        return services;
    }
}