using WEX.Edge.Notification.DTOs.Domain.Enums;

namespace Demo.EmailSender.ViewModels
{
    public class ContentViewModel
    {
        public EMailType Type { get; set; } = WEX.Edge.Notification.DTOs.Domain.Enums.EMailType.TEXT;
        public string Value { get; set; } = "this is a email sending test";
    }
}
