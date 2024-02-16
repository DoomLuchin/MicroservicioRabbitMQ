using MicroQueue.Domain.Core.Models;

namespace MicroQueue.Publisher.Application.Interfaces
{
    public interface ICommonService
    {      
        void SendCommonMessage(CommonMessage commonMessage);
    }
}
