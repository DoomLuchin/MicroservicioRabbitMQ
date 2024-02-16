using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Domain.Commands;
using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.Models;
using MicroQueue.Domain.Core.Historico;

namespace MicroQueue.Publisher.Application.Services
{
    public class CommonService : ICommonService
    {
        private readonly IEventBus _bus;
        private readonly IServicioHistorico _historico;
        public CommonService(IEventBus bus, IServicioHistorico historico)
        {
            _bus = bus;
            _historico = historico;
        }

        public void SendCommonMessage(CommonMessage commonMessage)
        {
            var createCommonCommand =
                new CreateCommonCommand
                (
                    commonMessage.Ruta,
                    commonMessage.IdUsuarioLog,
                    commonMessage.Token,
                    commonMessage.JsonMessage
                );            

            _bus.SendCommand(createCommonCommand);

            _historico.CrearHistoricoAsync(new HistoricoDTO
            {
                IdUsuario = createCommonCommand.IdUsuarioLog,
                Descripcion = "Create Common Queue for Ruta " + commonMessage.Ruta,
                TipoEvento = TipoEvento.CreateCommonQueue,
                Mensaje = createCommonCommand.JsonMessage
            });
        }
    }
}
