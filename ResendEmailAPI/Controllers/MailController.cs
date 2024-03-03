using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResendEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SendEmail(ResendAPI resendAPI)
        {
            await resendAPI.SendEmail();
            return Ok();
        }
    }
}
