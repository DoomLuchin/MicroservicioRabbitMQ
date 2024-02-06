using MicroQueue.Consumer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroQueue.Consumer.Data.Context
{
    public class ConsumerDbContext : DbContext
    {
        public ConsumerDbContext(DbContextOptions<ConsumerDbContext> options) : base(options)
        {
        }
        public DbSet<ManifiestoQueue> ManifiestoQueues { get; set; }
        public DbSet<MailQueue> MailQueues { get; set; }
    }
}
