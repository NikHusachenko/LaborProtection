using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
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

            builder.HasData(new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 1,
                LightFlux = 1060,
                Name = "ЛБ18",
                Power = 18,
                Price = 18,
                Type = BulbType.LB,
                Voltage = 57,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 2,
                LightFlux = 880,
                Name = "ЛД18",
                Power = 18,
                Price = 13,
                Type = BulbType.LD,
                Voltage = 57,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 3,
                LightFlux = 1060,
                Name = "ЛБ20",
                Power = 20,
                Price = 20,
                Type = BulbType.LB,
                Voltage = 57,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 4,
                LightFlux = 1060,
                Name = "ЛБ20-2",
                Power = 20,
                Price = 22,
                Type = BulbType.LB,
                Voltage = 65,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 5,
                LightFlux = 880,
                Name = "ЛД20-2",
                Power = 20,
                Price = 12,
                Type = BulbType.LD,
                Voltage = 65,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 6,
                LightFlux = 2020,
                Name = "ЛБ30",
                Power = 30,
                Price = 26,
                Type = BulbType.LB,
                Voltage = 106,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 7,
                LightFlux = 1980,
                Name = "ЛБУ30",
                Power = 30,
                Price = 25,
                Type = BulbType.LBU,
                Voltage = 104,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 8,
                LightFlux = 2800,
                Name = "ЛБ36",
                Power = 36,
                Price = 28,
                Type = BulbType.LB,
                Voltage = 103,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 9,
                LightFlux = 2800,
                Name = "ЛБ40",
                Power = 40,
                Price = 42,
                Type = BulbType.LB,
                Voltage = 103,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 10,
                LightFlux = 3000,
                Name = "ЛБ40-2",
                Power = 40,
                Price = 40,
                Type = BulbType.LB,
                Voltage = 110,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 11,
                LightFlux = 2300,
                Name = "ЛД40-2",
                Power = 40,
                Price = 40,
                Type = BulbType.LD,
                Voltage = 110,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 12,
                LightFlux = 4600,
                Name = "ЛБ65",
                Power = 65,
                Price = 45,
                Type = BulbType.LB,
                Voltage = 110,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 13,
                LightFlux = 5200,
                Name = "ЛБ80",
                Power = 80,
                Price = 45,
                Type = BulbType.LB,
                Voltage = 99,
            },
            new BulbEntity()
            {
                CreatedOn = DateTime.Now,
                Id = 14,
                LightFlux = 4250,
                Name = "ЛД80",
                Power = 80,
                Price = 42,
                Type = BulbType.LD,
                Voltage = 105,
            });
        }
    }
}