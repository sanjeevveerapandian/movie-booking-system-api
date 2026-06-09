using Microsoft.Extensions.DependencyInjection;
using MovieBooking.Application.Interfaces;
using MovieBooking.Application.Services;

namespace MovieBooking.Application.Extensions;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ITheaterService, TheaterService>();
        services.AddScoped<IScreenService, ScreenService>();

        return services;
    }
}