using Microsoft.Extensions.DependencyInjection;
using MovieBooking.Application.Interfaces;
using MovieBooking.Infrastructure.Email;
using MovieBooking.Infrastructure.Security;

namespace MovieBooking.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}