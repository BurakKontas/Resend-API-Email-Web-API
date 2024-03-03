using Resend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResendEmailAPI
{
    public class ResendAPI
    {
        private readonly IResend _resend;

        public ResendAPI(IResend resend)
        {
            _resend = resend;
        }
        public async Task SendEmail()
        {
            var message = new EmailMessage();
            message.From = "Acme <onboarding@resend.dev>";
            message.To.Add("aburakkontas@trakya.edu.tr");
            message.Subject = "Hello!";
            message.HtmlBody = "<div><strong>Greetings<strong> 👋🏻 from .NET</div>";
            message.Attachments = [];
            var file = File.ReadAllBytes("C:\\Users\\konta\\Desktop\\2023-2024bahardersprogrami (1).pdf");

            message.Attachments.Add(new EmailAttachment
            {
                Filename = "invoice.pdf",
                Content = file
            });

            await _resend.EmailSendAsync(message);
        }
    }
}
