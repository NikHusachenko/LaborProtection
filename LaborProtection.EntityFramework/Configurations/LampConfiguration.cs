using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
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

            builder.HasData(new LampEntity()
            {
                BulbCount = 4,
                CreatedOn = DateTime.Now,
                Height = 300,
                Id = 1,
                ImagePath = $"{Configuration.STATIC_FOLDER}EGLO 31756.png",
                Name = "EGLO 31756",
                Price = 1928,
                Type = LampType.LSP,
            },
            new LampEntity()
            {
                BulbCount = 2,
                CreatedOn = DateTime.Now,
                Height = 650,
                Id = 2,
                ImagePath = $"{Configuration.STATIC_FOLDER}Laguna Lightning.png",
                Name = "Laguna Lightning",
                Price = 1800,
                Type = LampType.LSO,
            },
            new LampEntity()
            {
                BulbCount = 4,
                CreatedOn = DateTime.Now,
                Height = 350,
                Id = 3,
                ImagePath = $"{Configuration.STATIC_FOLDER}BS-24.png",
                Name = "BS-24",
                Price = 479,
                Type = LampType.LSP,
            },
            new LampEntity()
            {
                BulbCount = 3,
                CreatedOn = DateTime.Now,
                Height = 700,
                Id = 4,
                ImagePath = $"{Configuration.STATIC_FOLDER}Sign 48.png",
                Name = "Sign 48",
                Price = 1169,
                Type = LampType.LSO,
            },
            new LampEntity()
            {
                BulbCount = 3,
                CreatedOn = DateTime.Now,
                Height = 150,
                Id = 5,
                ImagePath = $"{Configuration.STATIC_FOLDER}EuroLight.png",
                Name = "EuroLight",
                Price = 653,
                Type = LampType.OD,
            },
            new LampEntity()
            {
                BulbCount = 2,
                CreatedOn = DateTime.Now,
                Height = 200,
                Id = 6,
                ImagePath = $"{Configuration.STATIC_FOLDER}Brille BS-02.jpg",
                Name = "Brille BS-02",
                Price = 419,
                Type = LampType.LPO,
            },
            new LampEntity()
            {
                BulbCount = 2,
                CreatedOn = DateTime.Now,
                Height = 180,
                Id = 7,
                ImagePath = $"{Configuration.STATIC_FOLDER}MAGNUM PLF 30.jpg",
                Name = "MAGNUM PLF 30",
                Price = 267,
                Type = LampType.LPO,
            });
        }
    }
}