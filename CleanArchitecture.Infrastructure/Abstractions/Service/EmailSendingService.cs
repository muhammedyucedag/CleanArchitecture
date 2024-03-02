using CleanArchitecture.Application.Abstractions.Services;
using GenericEmailService;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Abstractions.Service
{
    //public class EmailSendingService : IEmailSendingService
    //{
    //    private readonly IMailService _mailService;
    //    private readonly EmailConfigurations _configurations;

    //    public EmailSendingService(IMailService emailService, EmailConfigurations configurations)
    //    {
    //        _mailService = emailService;
    //        _configurations = configurations;
    //    }

    //    public async Task SendEmailAsync()
    //    {
    //        var model = new Domain.Model.EmailModel<Attachment>(
    //            Configurations: _configurations,
    //            FromEmail: "mymail@gmail.com",
    //            ToEmails: new List<string> { "sendmail1@gmail.com", "sendmail2@gmail.com" },
    //            Subject: "Subjects",
    //            Body: "<b>Body</b>",
    //            Attachments: new List<Attachment>()
    //        );

    //        await _mailService.SendEmailWithNetAsync(model);
    //    }
    //}
}
