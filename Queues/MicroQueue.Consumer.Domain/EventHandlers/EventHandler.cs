using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.Events;
using MicroQueue.Domain.Core.Historico;
using MicroQueue.Domain.Core.Models;

namespace MicroQueue.Consumer.Domain.EventHandlers
{
    public class EventHandler
        :
        IEventHandler<CommonCreatedEvent>,
        IEventHandler<MailCreatedEvent>
    {
        private readonly IServicioHistorico _historico;
        private readonly HttpClient _clientLogCloudApi = new HttpClient();

        public EventHandler(IServicioHistorico historico)
        {
            _historico = historico;
        }

        public Task Handle(CommonCreatedEvent @event)
        {
            //llamar a tuta q se envia a la cola

            _historico.CrearHistoricoAsync(new HistoricoDTO
            {
                IdUsuario = @event.IdUsuarioLog,
                Descripcion = "Consume Common Queue for URL " + @event.Ruta,
                TipoEvento = TipoEvento.ConsumerCommonQueue,
                Mensaje = @event.JsonMessage
            });

            return Task.CompletedTask;
        }

        public Task Handle(MailCreatedEvent @event)
        {
            //Llamar a api para enviar mail

            _historico.CrearHistoricoAsync(new HistoricoDTO
            {
                IdUsuario = @event.IdUsuarioLog,
                Descripcion = "Consume Mail Queue",
                TipoEvento = TipoEvento.ConsumerEmailQueue,
                Mensaje = @event.JsonMessage
            });

            return Task.CompletedTask;
        }
    }
}
