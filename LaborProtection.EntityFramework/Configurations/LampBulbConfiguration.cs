using LaborProtection.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaborProtection.EntityFramework.Configurations
{
    public class LampBulbConfiguration : IEntityTypeConfiguration<LampBulbEntity>
    {
        public void Configure(EntityTypeBuilder<LampBulbEntity> builder)
        {
            builder.ToTable("LambBulb").HasKey(lb => new { lb.LampFK, lb.BulbFK });

            builder.HasOne<LampEntity>(lb => lb.Lamp)
                .WithMany(lamp => lamp.Bulbs)
                .HasForeignKey(lb => lb.LampFK);

            builder.HasOne<BulbEntity>(lb => lb.Bulb)
                .WithMany(bulb => bulb.Lamps)
                .HasForeignKey(lb => lb.BulbFK);
        }
    }
}