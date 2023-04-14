using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LaborProtection.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<LampEntity> Lamps { get; set; }
        public DbSet<BulbEntity> Bulbs { get; set; }

        public ApplicationContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.DEFAULT_CONNECTION);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LampConfiguration());
            modelBuilder.ApplyConfiguration(new BulbConfiguration());
        }
    }
}