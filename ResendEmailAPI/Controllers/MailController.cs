using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResendEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController(EmailSender emailSender, ResendAPI resendAPI) : ControllerBase
    {
        private readonly EmailSender _emailSender = emailSender;
        private readonly ResendAPI _resend = resendAPI;

        [HttpGet("smtp")]
        public async Task<IActionResult> SendEmail()
        {
            await _emailSender.SendEmail("aburakkontas@trakya.edu.tr", "Hello!");
            return Ok();
        }

        [HttpGet("resendapi")]
        public async Task<IActionResult> SendEmailAPI()
        {
            await _resend.SendEmail();
            return Ok();
        }
    }
}
