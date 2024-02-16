namespace MicroQueue.Publisher.Domain.Commands
{
    public class CreateCommonCommand : DocumentCommand
    {
        public CreateCommonCommand(string printer, string jsonMessage, string idUsuarioLog, string token)
        {
            Printer = printer;
            IdUsuarioLog = idUsuarioLog;
            Token = token;
            JsonMessage = jsonMessage;
        }
    }
}
