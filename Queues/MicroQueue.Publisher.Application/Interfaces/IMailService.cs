using MicroQueue.Domain.Core.Models;

namespace MicroQueue.Publisher.Application.Interfaces
{
    public interface IMailService
    {      
        void SendMailMessage(MailMessage mailMessage);
    }
}
