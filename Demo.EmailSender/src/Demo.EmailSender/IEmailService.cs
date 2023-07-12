using Demo.EmailSender.ViewModels;
using WEX.Edge.Core.Wrappers;

namespace Demo.EmailSender
{
    public interface IEmailService
    {
        Task<Response<bool>> SendEmailAsync(EmailRequestViewModel model, string token);
    }
}