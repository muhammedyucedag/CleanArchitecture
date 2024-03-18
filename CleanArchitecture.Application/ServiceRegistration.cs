using CleanArchitecture.WepApi.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            ConfigureServiceExtension.ApplicationServiceRegistration(services, configuration);
        }
    }
}
