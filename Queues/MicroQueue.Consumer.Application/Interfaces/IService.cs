using MicroQueue.Domain.Core.LogsAlliance;

namespace MicroQueue.Consumer.Application.Interfaces
{
    public interface IService
    {
        List<Historico> GetConsumerQueue(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento);
    }
}
