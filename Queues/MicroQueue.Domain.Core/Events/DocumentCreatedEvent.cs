namespace MicroQueue.Domain.Core.Events
{
    public class DocumentCreatedEvent : Event
    {
        public string Printer { get; set; } = string.Empty;

        public DocumentCreatedEvent(string printer, string idUsuarioLog, string token, string jsonMessage)
        {
            Printer = printer;
            IdUsuarioLog = idUsuarioLog;
            Token = token;
            JsonMessage = jsonMessage;
        }
    }
}
