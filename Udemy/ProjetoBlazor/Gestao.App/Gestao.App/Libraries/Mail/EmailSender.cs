using Gestao.App.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace Gestao.App.Libraries.Mail
{
    public class EmailSender(ILogger<EmailSender> logger, IConfiguration configuration, SmtpClient smtpClient)
        : IEmailSender<ApplicationUser>
    {
        private readonly ILogger _logger = logger;
        private readonly SmtpClient _smtpClient = smtpClient;
        private readonly IConfiguration _configuration = configuration;


        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            string text =
                "<html lang=\"en\">" +
                "   <head></head>" +
                "   <body>Please confirm your account by " +
                $"      <a href='{confirmationLink}'>clicking here</a>." +
                "  </body>" +
                "</html>";

            await SendEmailAsync(email, "Confirmação de E-mail", text);
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            string message =
                "<html lang=\"en\">" +
                "   <head></head>" +
                "   <body>Please reset your password by " +
                $"      <a href='{resetLink}'>clicking here</a>." +
                "  </body>" +
                "</html>";

            await SendEmailAsync(email, "Resete seu e-mail", message);
        }

        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            string message =
                "<html lang=\"en\">" +
                "   <head></head>" +
                "   <body>Please reset your password " +
                $"      using the following code:<br>{resetCode}" +
                "   </body>" +
                "</html>";

            await SendEmailAsync(email, "Resete sua senha", message);
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            await Execute(subject, message, toEmail);
        }

        public async Task Execute(string subject, string message, string toEmail)
        {
            // Substituir Mandrill por SMTP - Gmail
            //var api = new MandrillApi(apiKey);
            //var mandrillMessage = new MandrillMessage("sarah@contoso.com", toEmail, subject, message);
            //await api.Messages.SendAsync(mandrillMessage);

            MailMessage mailMessage = new();
            mailMessage.From = new MailAddress(_configuration.GetValue<string>("EmailSender:Credential:Username")!);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(toEmail));

            await _smtpClient.SendMailAsync(mailMessage);

            _logger.LogInformation("Email to {EmailAddress} sent!", toEmail);
        }
    }
}
