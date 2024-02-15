using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Domain.Commands;
using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.Models;
using MicroQueue.Domain.Core.Historico;

namespace MicroQueue.Publisher.Application.Services
{
    public class Service : IService
    {
        private readonly IEventBus _bus;
        private readonly IServicioHistorico _historico;
        public Service(IEventBus bus, IServicioHistorico historico)
        {
            _bus = bus;
            _historico = historico;
        }

        public void SendMailMessage(MailMessage mailMessage)
        {
            var createMailCommand =
                new CreateMailCommand
                (
                    mailMessage.To,
                    mailMessage.From,
                    mailMessage.Body,
                    mailMessage.IdUsuarioLog,
                    mailMessage.Token,
                    mailMessage.JsonMessage
                );            

            _bus.SendCommand(createMailCommand);

            _historico.CrearHistoricoAsync(new HistoricoDTO
            {
                IdUsuario = createMailCommand.IdUsuarioLog,
                Descripcion = "Create Email Queue",
                TipoEvento = TipoEvento.CreateEmailQueue,
                Mensaje = createMailCommand.JsonMessage
            });
        }

        public void SendDocumentMessage(DocumentMessage documentMessage)
        {
            var createDocumentCommand =
                new CreateDocumentCommand
                (
                    documentMessage.Printer,
                    documentMessage.IdUsuarioLog,
                    documentMessage.Token,
                    documentMessage.JsonMessage
                );            

            _bus.SendCommand(createDocumentCommand);
        }
    }
}
