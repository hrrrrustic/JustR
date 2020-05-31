using JustR.Core.Entity;
using JustR.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JustR.ProfileService
{
    public class ProfileDbContext : DbContext
    {
       public DbSet<User> Users { get; set; }

       public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
       {
       }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
       }
    }
}       