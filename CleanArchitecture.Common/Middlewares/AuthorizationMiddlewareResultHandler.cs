using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;
using System.Text.Json;

namespace CleanArchitecture.Common.Middlewares
{
    public class AuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly Microsoft.AspNetCore.Authorization.Policy.AuthorizationMiddlewareResultHandler defaultHandler = new();
        private readonly IConfiguration _configuration;

        public AuthorizationMiddlewareResultHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            ////var accessTokenClaim = context.User.FindFirst(CustomClaimTypes.Subject);
            //if (accessTokenClaim is null || accessTokenClaim.Value != "Access")
            //{
            //    await ErrorAsync(context, "Invalid access token");
            //    return;
            //}

            if (!authorizeResult.Succeeded)
            {
                await ErrorAsync(context, string.Join(Environment.NewLine, authorizeResult?.AuthorizationFailure?.FailedRequirements?.Select(x => x.ToString()) ?? Array.Empty<string>()));
                return;
            }

            await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }

        private async Task ErrorAsync(HttpContext context, string message)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                ErrorType = "Authorization",
                Message = message,
                Succeeded = false
            }));
        }
    }
}
