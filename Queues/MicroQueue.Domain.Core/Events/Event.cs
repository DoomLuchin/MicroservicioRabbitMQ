namespace MicroQueue.Domain.Core.Events
{
    public abstract class Event
    {
        public string IdUsuarioLog { get; protected set; } = string.Empty;
        public DateTime FechaCreacion { get; protected set; }
        public string Token { get; protected set; } = string.Empty;
        public string JsonMessage { get; protected set; } = string.Empty;

        protected Event()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
