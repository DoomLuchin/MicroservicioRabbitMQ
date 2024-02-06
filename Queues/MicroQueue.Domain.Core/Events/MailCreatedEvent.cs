namespace MicroQueue.Domain.Core.Events
{
    public class MailCreatedEvent : Event
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        public MailCreatedEvent(string to, string from, string body, string idUsuarioLog, string token, string jsonMessage)
        {
            To = to;
            From = from;
            Body = body;
            IdUsuarioLog = idUsuarioLog;
            Token = token;
            JsonMessage = jsonMessage;
        }
    }
}
