using MicroQueue.Domain.Core.LogsAlliance;
using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Domain.Commands;
using System;

namespace MicroQueue.Publisher.Application.Interfaces
{
    public interface IService
    {      
        void SendDocumentMessage(DocumentMessage documentMessage);
        void SendMailMessage(MailMessage mailMessage);
        List<Historico> GetPublisherQueue(DateTime fechaInicio, DateTime fechaFin, string tipo, string evento);
    }
}
