namespace MicroQueue.Publisher.Domain.Commands
{
    public class CreateCommonCommand : CommonCommand
    {
        public CreateCommonCommand(string ruta, string idUsuarioLog, string token, string jsonMessage)
        {
            Ruta = ruta;
            IdUsuarioLog = idUsuarioLog;
            Token = token;
            JsonMessage = jsonMessage;
        }
    }
}
