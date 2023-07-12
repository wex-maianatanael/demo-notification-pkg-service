namespace Demo.EmailSender.ViewModels
{
    public class EmailRequestViewModel
    {
        public string? From { get; set; } = "no-reply@wexedge.com";
        public List<string>? Tos { get; set; } = new List<string>() { "natanael.maia@wexinc.com" };
        public string? Subject { get; set; } = "test";
        public List<ContentViewModel>? Contents { get; set; } = new List<ContentViewModel>()
        {
            new ContentViewModel()
            {
                Type = WEX.Edge.Notification.DTOs.Domain.Enums.EMailType.TEXT,
                Value = "this is a email sending test"
            }
        };
    }
}
