using MicroQueue.Consumer.Data.Context;
using MicroQueue.Consumer.Domain.Interfaces;
using MicroQueue.Consumer.Domain.Models;

namespace MicroQueue.Consumer.Data.Repository
{
    public class Repository : IRepositoryQueue
    {
        private ConsumerDbContext _context;

        public Repository(ConsumerDbContext context)
        {
            _context = context;
        }

        public void AddMailQueue(MailQueue mailQueue)
        {
            _context.Add(mailQueue);
            _context.SaveChanges();
        }

        public void UpdateMailQueue(MailQueue mailQueue)
        {
            var queue = _context.MailQueues.Where(x => x.Id == mailQueue.Id).FirstOrDefault();

            if (queue != null)
            {
                queue.MessageResponse = "se actualizo";
                _context.Update(queue);
                _context.SaveChanges();
            }

        }

        public void AddManifiestoQueue(ManifiestoQueue manifiestoQueue)
        {
            _context.Add(manifiestoQueue);
            _context.SaveChanges();
        }

        public IEnumerable<MailQueue> GetMailQueues()
        {
            return _context.MailQueues;
        }

        public IEnumerable<ManifiestoQueue> GetManifiestoQueues()
        {
            return _context.ManifiestoQueues;
        }
    }
}
