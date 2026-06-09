using Microsoft.Extensions.DependencyInjection;
using MovieBooking.Application.Interfaces;
using MovieBooking.Infrastructure.Security;

namespace MovieBooking.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}