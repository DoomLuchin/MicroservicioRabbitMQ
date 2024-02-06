using MicroQueue.Domain.Core.Commands;

namespace MicroQueue.Publisher.Domain.Commands
{
    public abstract class DocumentCommand : Command
    {        
        public string Printer { get; set; } = string.Empty;
    }
}
