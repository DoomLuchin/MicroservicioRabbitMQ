using MicroQueue.Domain.Core.Commands;

namespace MicroQueue.Publisher.Domain.Commands
{
    public abstract class CommonCommand : Command
    {        
        public string Ruta { get; set; } = string.Empty;
    }
}
