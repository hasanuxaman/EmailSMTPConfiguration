using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMTPConfiguration.Service;

namespace SMTPConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly EmailService _email;

        public MailController(EmailService email)
        {
            _email = email;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail()
        {
            await _email.SendEmailAsync(
                "aliakber@dekkoisho.com",
                "Test Email from ASP.NET Core",
                "<h1>Hello from outlook SMTP!</h1>"
            );

            return Ok("Mail Sent");
        }
    }
}
