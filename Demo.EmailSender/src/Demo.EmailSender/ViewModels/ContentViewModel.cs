using WEX.Edge.Notification.DTOs.Domain.Enums;

namespace Demo.EmailSender.ViewModels
{
    public class ContentViewModel
    {
        public EMailType Type { get; set; }
        public string Value { get; set; }
    }
}
