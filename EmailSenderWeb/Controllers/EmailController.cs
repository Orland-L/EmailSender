using EmailSenderAPI;
using EmailSenderWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailSenderWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailSenderCredential _credential;
        private readonly ILogger<EmailSenderService> _logger;

        public EmailController(IOptions<EmailSenderCredential> options, ILogger<EmailSenderService> logger)
        {
            _credential = options.Value;
            _logger = logger;
        }

        // POST api/<EmailController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EmailSendFormModel emailSendForm)
        {
            if (string.IsNullOrEmpty(_credential.Host) || string.IsNullOrEmpty(_credential.Email) || string.IsNullOrEmpty(_credential.Password))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailSendService = new EmailSenderService(_credential, _logger);
            try {
                await emailSendService.SendMailAsync(emailSendForm.Recipient, emailSendForm.Subject, emailSendForm.Body);
                return Ok();
            }
            catch(EmailSendException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout);
            }
        }
    }
}
