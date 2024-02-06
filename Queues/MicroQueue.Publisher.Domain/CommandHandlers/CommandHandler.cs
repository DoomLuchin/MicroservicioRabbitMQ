using MediatR;
using MicroQueue.Publisher.Domain.Commands;
using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.Events;

namespace MicroQueue.Publisher.Domain.CommandHandlers
{
    public class CommandHandler 
        : 
        IRequestHandler<CreateDocumentCommand, bool>, 
        IRequestHandler<CreateMailCommand, bool>
    {
        private readonly IEventBus _bus;

        public CommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        #region Logica para publicar el mensaje dentro del event bus de rabbitmq

        public Task<bool> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new DocumentCreatedEvent(request.Printer, request.IdUsuarioLog, request.Token, request.JsonMessage));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(CreateMailCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new MailCreatedEvent(request.To, request.From, request.Body, request.IdUsuarioLog, request.Token, request.JsonMessage));

            return Task.FromResult(true);
        }

        #endregion
    }
}
