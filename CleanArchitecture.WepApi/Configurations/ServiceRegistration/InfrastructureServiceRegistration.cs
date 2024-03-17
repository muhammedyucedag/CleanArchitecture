using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Configurations;
using CleanArchitecture.Infrastructure.OptionsSetup;

namespace CleanArchitecture.WepApi.Configurations.ServiceRegistration;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
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
