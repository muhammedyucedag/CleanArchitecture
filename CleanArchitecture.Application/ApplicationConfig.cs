using AutoMapper;
using CleanArchitecture.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application;

public static class ApplicationConfig
{
    // AutoMapper ve MediatR'ın yapılandırılması için bir metod.
    // services: Hizmetlerin koleksiyonunu temsil eden IServiceCollection nesnesi.
    public static void ConfigureAutoMapper(IServiceCollection services, ConfigurationManager _configurationManager)
    {
        // MediatR'ın yapılandırılması
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration)));

        // Pipeline davranışlarının eklenmesi
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // AutoMapper profil sınıflarının bulunması ve eklenmesi
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes();
        var mappingProfiles = types.Where(type => type.IsAssignableTo(typeof(Profile)));

        foreach (var mappingProfile in mappingProfiles)
            services.AddAutoMapper(mappingProfile); // Her profil sınıfı için AutoMapper'a ekleme yapılıyor
    }
}
