using MicroQueue.Domain.Core.Models;

namespace MicroQueue.Publisher.Application.Interfaces
{
    public interface IService
    {      
        void SendDocumentMessage(DocumentMessage documentMessage);
        void SendMailMessage(MailMessage mailMessage);
    }
}
