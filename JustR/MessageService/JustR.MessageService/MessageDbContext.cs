using JustR.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace JustR.MessageService
{
    public class MessageDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ServiceConfigurations.DbConnectionString);
        }
    }
}