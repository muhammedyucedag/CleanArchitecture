using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class ConfigureServiceExtension
{
    public static void ApplicationServiceRegistration(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}
