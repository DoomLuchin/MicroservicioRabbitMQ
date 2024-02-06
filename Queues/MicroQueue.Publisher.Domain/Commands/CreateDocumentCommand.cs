namespace MicroQueue.Publisher.Domain.Commands
{
    public class CreateDocumentCommand : DocumentCommand
    {
        public CreateDocumentCommand(string printer, string jsonMessage, string idUsuarioLog, string token)
        {
            Printer = printer;
            IdUsuarioLog = idUsuarioLog;
            Token = token;
            JsonMessage = jsonMessage;
        }
    }
}
