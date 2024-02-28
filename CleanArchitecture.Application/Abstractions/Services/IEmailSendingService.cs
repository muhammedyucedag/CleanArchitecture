namespace CleanArchitecture.Application.Abstractions.Services;

public interface IEmailSendingService
{
    Task SendEmailAsync();
}
