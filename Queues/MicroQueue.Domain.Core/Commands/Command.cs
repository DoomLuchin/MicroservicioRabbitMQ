using MicroQueue.Domain.Core.Events;

namespace MicroQueue.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public string IdUsuarioLog { get; protected set; } = string.Empty;
        public DateTime FechaCreacion { get; protected set; }
        public string Token { get; protected set; } = string.Empty;
        public string JsonMessage { get; protected set; } = string.Empty;

        protected Command()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
