using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ResendEmailAPI
{
    public class EmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Task> SendEmail(string toEmail, string subject)
        {
            var mailSettings = _configuration.GetSection("MailSettings");

            // Set up SMTP client
            SmtpClient client = new SmtpClient(mailSettings["Server"], int.Parse(mailSettings["Port"]));
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mailSettings["UserName"], mailSettings["Password"]);

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress($"{mailSettings["SenderName"]} <{mailSettings["SenderEmail"]}>");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("<div><strong>Greetings<strong> 👋🏻 from .NET</div>");
            mailMessage.Body = mailBody.ToString();
            mailMessage.Attachments.Add(new Attachment("C:\\Users\\konta\\Desktop\\2023-2024bahardersprogrami (1).pdf"));

            // Send email
            await client.SendMailAsync(mailMessage);
            return Task.CompletedTask;
        }
    }
}
