using LaborProtection.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborProtection.EntityFramework.Configurations
{
    public class BulbConfiguration : IEntityTypeConfiguration<BulbEntity>
    {
        public void Configure(EntityTypeBuilder<BulbEntity> builder)
        {
            builder.ToTable("Bulbs").HasKey(bulb => bulb.Id);

            builder.Property(bulb => bulb.Name).HasMaxLength(63).IsRequired();
        }
    }
}