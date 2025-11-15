using Microsoft.Extensions.Options;
using SMTPConfiguration.Models;
using System.Net;
using System.Net.Mail;

namespace SMTPConfiguration.Service
{
    public class EmailService
    {

        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var mail = new MailMessage()
            {
                From = new MailAddress(_settings.From),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(toEmail);

            using var smtp = new SmtpClient(_settings.Host)
            {
                Port = _settings.Port,
                Credentials = new NetworkCredential(_settings.UserName, _settings.Password),
                EnableSsl = _settings.EnableSSL
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
