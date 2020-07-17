using JustR.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JustR.FriendService
{
    public class FriendDbContext : DbContext
    {
        public DbSet<Relationship> Relationships { get; set; }

        public FriendDbContext(DbContextOptions<FriendDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relationship>().HasKey(k => new {k.FirstUserId, k.SecondUserId});
        }
    }
}