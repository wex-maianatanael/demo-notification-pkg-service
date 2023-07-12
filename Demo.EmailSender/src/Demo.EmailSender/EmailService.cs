using Demo.EmailSender.ViewModels;
using WEX.Edge.Core.DTOs.AuthWexEdge;
using WEX.Edge.Core.Wrappers;
using WEX.Edge.Notification.Clients.Interfaces;
using WEX.Edge.Notification.DTOs.Email;

namespace Demo.EmailSender
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly INotificationClient _notificationClient;

        public EmailService(ILogger<EmailService> logger, INotificationClient notificationClient)
        {
            _logger = logger;
            _notificationClient = notificationClient;
        }

        public async Task<Response<bool>> SendEmailAsync(EmailRequestViewModel model, string token)
        {
            try
            {
                var emailRequest = new EmailRequest()
                {
                    From = model.From,
                    Tos = model.Tos,
                    Subject = model.Subject,
                    Contents = new List<Content>()
                    {
                        new Content()
                        {
                            Type = model.Contents.FirstOrDefault().Type,
                            Value = model.Contents.FirstOrDefault().Value
                        }
                    }
                };

                var authenticationData = new AuthWexEdgeResponse()
                {
                    Login = new Login()
                    {
                        Success = true,
                        Token = token
                    }
                };

                var notification = await _notificationClient.NotificationSendEmail(emailRequest, authenticationData);

                return notification;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending the email via notification service: {ex.Message}", ex);
                throw;
            }
        }
    }
}
