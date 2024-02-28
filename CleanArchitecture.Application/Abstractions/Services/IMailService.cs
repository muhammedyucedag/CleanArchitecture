using CleanArchitecture.Domain.Model;
using System.Net.Mail;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IMailService
{
    Task SendEmailWithNetAsync(EmailModel<Attachment> model);
}
