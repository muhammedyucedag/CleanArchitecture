using CleanArchitecture.Domain.Entites.ErrorLog;
using CleanArchitecture.Persistance.Context;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Common.Middleware;

public sealed class ExcepitonMiddleware : IMiddleware
{   
    private readonly AppDbContext _context;

    public ExcepitonMiddleware(AppDbContext context)
    {
        _context = context;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await LogExcepitonToDatabaseAsync(ex, context.Request);
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

    private async Task LogExcepitonToDatabaseAsync(Exception ex, HttpRequest request)
    {
        ErrorLog errorLog = new()
        {
            ErrorMessage = ex.Message,
            StackTrace = ex.StackTrace,
            RequestPath = request.Path,
            RequestMethod = request.Method,
            TimeStamp = DateTime.Now,
        };

        await _context.Set<ErrorLog>().AddAsync(errorLog, default);
        await _context.SaveChangesAsync();
    }
}
