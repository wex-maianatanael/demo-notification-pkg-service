using Demo.EmailSender.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.EmailSender.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly ILogger<EmailsController> _logger;        
        private readonly IAuthervice _authService;
        private readonly IEmailService _emailService;

        public EmailsController(ILogger<EmailsController> logger, IAuthervice authService, IEmailService emailService)
        {
            _logger = logger;
            _authService = authService;
            _emailService = emailService;            
        }

        [HttpPost("send")]
        public async Task<IActionResult> PostAsync(EmailRequestViewModel model)
        {
            try
            {
                var authResponse = _authService.Authenticate();
                if (authResponse.StatusCode != HttpStatusCode.OK) return BadRequest("Error to authenticate the user in Auth2 service.");

                var notification = await _emailService.SendEmailAsync(model, authResponse.AccessToken);
                if (notification.Succeeded || (notification.Errors == null || notification.Errors.Count == 0)) return Ok("Email sent.");

                return BadRequest("The email was not sent.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
