using LaborProtection.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborProtection.EntityFramework.Configurations
{
    public class LampConfiguration : IEntityTypeConfiguration<LampEntity>
    {
        public void Configure(EntityTypeBuilder<LampEntity> builder)
        {
            builder.ToTable("Lamps").HasKey(lamp => lamp.Id);

            builder.Property(lamp => lamp.Name).HasMaxLength(63).IsRequired();
        }
    }
}