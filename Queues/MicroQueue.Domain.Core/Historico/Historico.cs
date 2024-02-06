namespace MicroQueue.Domain.Core.LogsAlliance
{
    public class Historico : IHistorico
    {
        public Guid? IdRelacionGuid { get; set; }
        public Guid? IdRelacionVarchar { get; set; }
        public string IdUsuario { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; private set; }
        public string Tipo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Evento { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;

        public Historico()
        {
            FechaCreacion = DateTime.Now;
        }

        public void AddHiscorico(Historico historicoQueue)
        {
            throw new NotImplementedException();
        }

        public List<Historico> GetHiscorico(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento)
        {
            throw new NotImplementedException();
        }
    }
}
