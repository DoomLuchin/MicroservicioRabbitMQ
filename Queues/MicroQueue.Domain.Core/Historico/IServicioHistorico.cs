namespace MicroQueue.Domain.Core.Historico
{
    public interface IServicioHistorico
    {
        Task<HistoricoDTO> CrearHistoricoAsync(HistoricoDTO historico);
    }
}
