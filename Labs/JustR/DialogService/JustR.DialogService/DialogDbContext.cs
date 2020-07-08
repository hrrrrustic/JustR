using JustR.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace JustR.DialogService
{
    public class DialogDbContext : DbContext
    {
        public DbSet<Dialog> Dialogs { get; set; }

        public DialogDbContext(DbContextOptions<DialogDbContext> context) : base(context)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ServiceConfiguration.DbConnectionString);
        }
    }
}