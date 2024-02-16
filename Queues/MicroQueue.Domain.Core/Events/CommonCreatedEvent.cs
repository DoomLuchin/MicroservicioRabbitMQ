namespace MicroQueue.Domain.Core.Events
{
    public class CommonCreatedEvent : Event
    {
        public string Ruta { get; set; } = string.Empty;

        public CommonCreatedEvent(string ruta, string idUsuarioLog, string token, string jsonMessage)
        {
            Ruta = ruta;
            IdUsuarioLog = idUsuarioLog;
            Token = token;
            JsonMessage = jsonMessage;
        }
    }
}
