namespace MicroQueue.Domain.Core.Models
{
    public class MessageInfo
    {
        public string IdUsuarioLog { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string Token { get; set; } = string.Empty;
        public string JsonMessage { get; set; } = string.Empty;

        public MessageInfo()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
