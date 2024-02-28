using CleanArchitecture.Application.Abstractions.Services;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Abstractions.Service;

public class MailService : IMailService
{
    public async Task SendEmailWithNetAsync(Domain.Model.EmailModel<Attachment> model)
    {
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(model.FromEmail);
            foreach (var email in model.ToEmails)
            {
                mail.To.Add(email);
            }
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = model.Configurations.Html;
            if (model.Attachments != null)
            {
                foreach (var attachment in model.Attachments)
                {
                    mail.Attachments.Add(attachment);
                }
            }
            using (SmtpClient smtp = new SmtpClient(model.Configurations.Smtp))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(model.FromEmail, model.Configurations.Password);
                smtp.EnableSsl = model.Configurations.SSL;
                smtp.Port = model.Configurations.Port;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
