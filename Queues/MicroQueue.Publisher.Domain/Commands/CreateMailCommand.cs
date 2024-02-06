namespace MicroQueue.Publisher.Domain.Commands
{
    public class CreateMailCommand : MailCommand
    {
        public CreateMailCommand(string to, string from, string body, string idUsuarioLog, string token, string jsonMessage)
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
