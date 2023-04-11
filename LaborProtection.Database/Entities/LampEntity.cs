using static LaborProtection.Common.LightSystem;

namespace LaborProtection.Database.Entities
{
    public class LampEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public LightType Type { get; set; }
        public float Price { get; set; }
        public ushort BulbCount { get; set; }
        public float Height { get; set; }
    }
}