using MicroQueue.Domain.Core.Commands;

namespace MicroQueue.Publisher.Domain.Commands
{
    public abstract class MailCommand : Command
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
