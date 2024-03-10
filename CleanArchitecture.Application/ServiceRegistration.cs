using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class ServiceRegistration
{
    // IServiceCollection'a yeni bir metod ekler. Bu metod, uygulama servislerini yapılandırmak için kullanılır.
    // _configurationManager, yapılandırma bilgilerine erişim sağlar.
    public static void AddApplicationServices(this IServiceCollection collection, ConfigurationManager _configurationManager)
    {
        // AutoMapper'ı yapılandırmak için ApplicationConfig sınıfındaki ConfigureAutoMapper metodunu çağırır.
        ApplicationConfig.ConfigureAutoMapper(collection, _configurationManager);
    }
}
