namespace MicroQueue.Domain.Core.Models
{
    public class MailMessage : MessageInfo
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
