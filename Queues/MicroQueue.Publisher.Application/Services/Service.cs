using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Domain.Commands;
using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.LogsAlliance;
using MicroQueue.Domain.Core.Models;

namespace MicroQueue.Publisher.Application.Services
{
    public class Service : IService
    {
        private readonly IEventBus _bus;
        private readonly IHistorico _historico;
        public Service(IEventBus bus, IHistorico historico)
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

            _historico.AddHiscorico(new Historico
            {
                IdUsuario = createMailCommand.IdUsuarioLog,
                Descripcion = "Create Email Queue",
                Evento = Constantes.Evento.CreateEmailQueue,
                Tipo = Constantes.Tipo.Queue,
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

            _historico.AddHiscorico(new Historico
            {
                IdUsuario = createDocumentCommand.IdUsuarioLog,
                Descripcion = "Create Document Queue",
                Evento = Constantes.Evento.CreateDocumentQueue,
                Tipo = Constantes.Tipo.Queue,
                Mensaje = createDocumentCommand.JsonMessage
            });
        }

        public List<Historico> GetPublisherQueue(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento)
        {
            List<Historico> historicoList =
                _historico.GetHiscorico(fechaInicio, fechaFin, tipo, evento);

            return historicoList;
        }
    }
}
