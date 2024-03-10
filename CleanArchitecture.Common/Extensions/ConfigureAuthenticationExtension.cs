using System.Text;

namespace CleanArchitecture.Common.Extensions
{
    public static class ConfigureAuthenticationExtension
    {
        //public static void AddAuthenticationServices(this IServiceCollection services, ConfigurationManager configurationManager)
        //{
        //    services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();
        //    services
        //        .AddAuthentication(options =>
        //        {
        //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //        })
        //        .AddJwtBearer(options =>
        //        {
        //            _ConfigureOptions(options, configurationManager);
        //        });

        //}

        //private static void _ConfigureOptions(JwtBearerOptions options, ConfigurationManager configurationManager)
        //{
        //    options.TokenValidationParameters = new()
        //    {
        //        ValidateAudience = true,
        //        ValidateIssuer = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        NameClaimType = ClaimTypes.NameIdentifier,
        //        // RoleClaimType = ClaimTypes.Role,
        //        ValidAudience = configurationManager["Token:Audience"],
        //        ValidIssuer = configurationManager["Token:Issuer"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["Token:SecurityKey"])),
        //    };

        //    options.Events = new JwtBearerEvents
        //    {
        //        OnMessageReceived = context =>
        //        {
        //            var accessToken = context.HttpContext.Request.Query["access_token"];

        //            // If the request is for our hub...
        //            var path = context.HttpContext.Request.Path;
        //            if (!string.IsNullOrEmpty(accessToken) &&
        //                (path.StartsWithSegments("/api/hubs")))
        //            {
        //                // Read the token out of the query string
        //                context.Token = accessToken;
        //            }

        //            if (context.HttpContext.Request.Cookies.ContainsKey("X-Access-Token"))
        //                context.Token = context.HttpContext.Request.Cookies["X-Access-Token"];

        //            return Task.CompletedTask;
        //        },
        //        OnChallenge = context =>
        //        {
        //            return Task.CompletedTask;
        //        },
        //        OnAuthenticationFailed = context => {
        //            context.NoResult();
        //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //            context.Response.ContentType = MediaTypeNames.Application.Json;
        //            context.Response.WriteAsync(JsonSerializer.Serialize(new
        //            {
        //                ErrorType = "Authorization",
        //                Message = context.Exception.Message,
        //                Succeeded = false
        //            })).Wait();
        //            context.Response.CompleteAsync().Wait();
        //            return Task.CompletedTask;
        //        },
        //        OnTokenValidated = context =>
        //        {
        //            Console.WriteLine($"Login Success:{context.Principal.Identity}");
        //            var roleClaim = context.Principal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);
        //            if (roleClaim != null)
        //            {
        //                var identity = context.Principal.Identity as ClaimsIdentity;
        //                if (identity != null)
        //                {
        //                    identity.AddClaim(new Claim(ClaimTypes.Role, roleClaim.Value));
        //                }
        //            }
        //            return Task.CompletedTask;
        //        }
        //    };
        //}
    }
}
