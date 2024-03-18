using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Configurations;
using CleanArchitecture.Infrastructure.OptionsSetup;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        EmailConfigurations configurations = new(
                                      Stmp: "smtp.example.com",
                                      Password: "password",
                                      Port: 587,
                                      SSL: true,
                                      Html: true);

        services.AddSingleton(configurations);

        services.AddScoped<IJwtProvider, JwtProvider>();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
    }
}
