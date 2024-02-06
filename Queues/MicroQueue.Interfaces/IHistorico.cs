using MicroQueue.Models;

namespace MicroQueue.Historico
{
    public interface IHistorico
    {
        void AddHiscoricoQueue(Historico historicoQueue);
        List<Historico> GetHiscoricoQueue(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento);
    }
}
