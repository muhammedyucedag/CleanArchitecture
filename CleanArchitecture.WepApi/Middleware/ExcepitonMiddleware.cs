using FluentValidation;

namespace CleanArchitecture.WepApi.Middleware;

public sealed class ExcepitonMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
			try
			{
				await next(context);
			}
			catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var contentType = "application/json";

        context.Response.ContentType = contentType;
        context.Response.StatusCode = 500;

        if (ex.GetType() == typeof(ValidationException))
        {
            var validationException = (ValidationException)ex;

            return context.Response.WriteAsync(new ValidationErrorDetails
            {
                Errors = validationException.Errors.Select(s => s.PropertyName),
                StatusCode = 403
            }.ToString());
        }

        return context.Response.WriteAsync(new ErrorResult
        {
            Message = ex.Message,
            StatusCode = context.Response.StatusCode
        }.ToString());

    }
}
