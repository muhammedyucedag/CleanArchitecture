using Microsoft.AspNetCore.Builder;

namespace CleanArchitecture.Common.Middleware;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app) 
    { 
        app.UseMiddleware<ExcepitonMiddleware>();
        return app;
    }
}
