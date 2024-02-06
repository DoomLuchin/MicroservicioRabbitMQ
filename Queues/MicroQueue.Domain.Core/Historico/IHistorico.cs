namespace MicroQueue.Domain.Core.LogsAlliance
{
    public interface IHistorico
    {
        void AddHiscorico(Historico historicoQueue);
        List<Historico> GetHiscorico(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento);
    }
}