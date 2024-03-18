using Microsoft.AspNetCore.Builder;

namespace CleanArchitecture.Persistance.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
            return applicationBuilder;
        }
    }
}
