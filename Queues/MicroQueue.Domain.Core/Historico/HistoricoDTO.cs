namespace MicroQueue.Domain.Core.Historico
{
    public class HistoricoDTO
    {
        public HistoricoDTO()
        {
            FechaCreacion = DateTime.Now;
        }

        public string? IdUsuario { get; set; }
        public Guid? IdRelacionGuid { get; set; }
        public string? IdRelacionVarchar { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Descripcion { get; set; }
        public int TipoEvento { get; set; }
        public string? Mensaje { get; set; }
    }

    public class TipoEvento
    {
        public const int CreateEmailQueue = 5;
        public const int CreateCommonQueue = 6;
        public const int ConsumerEmailQueue = 7;
        public const int ConsumerDocumentQueue = 8;
    }

    public static class HistoricoServices
    {
        public const string ApiLogsAlliance = "ApiLogsAlliance";
        public const string HeaderLogsAlliance = "Api-Key";
    }

    public class HistoricoSettings
    {
        public string URL { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
    }
}
