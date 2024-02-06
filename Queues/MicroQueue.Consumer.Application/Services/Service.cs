using MicroQueue.Consumer.Application.Interfaces;
using MicroQueue.Domain.Core.LogsAlliance;

namespace MicroQueue.Consumer.Application.Services
{
    public class Service : IService
    {
        private readonly IHistorico _historico;
        public Service(IHistorico historico)
        {
            _historico = historico;
        }

        public List<Historico> GetConsumerQueue(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento)
        {
            List<Historico> historicoList =
            _historico.GetHiscorico(fechaInicio, fechaFin, tipo, evento);

            return historicoList;
        }
    }
}
