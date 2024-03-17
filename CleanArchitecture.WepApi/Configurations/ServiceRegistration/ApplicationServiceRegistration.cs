using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.WepApi.Configurations.ServiceRegistration;

public class ApplicationServiceRegistration
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));
        //services.AddMediatR(typeof(Program));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
    }
}
