using LaborProtection.Database.Enums;

namespace LaborProtection.Database.Entities
{
    public class LampEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public LampType Type { get; set; }
        public float Price { get; set; }
        public ushort BulbCount { get; set; }
        public float Height { get; set; }
        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}