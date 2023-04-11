using LaborProtection.Database.Enums;

namespace LaborProtection.Database.Entities
{
    public class BulbEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public BulbType Type { get; set; }
        public short Voltage { get; set; }
        public short Power { get; set; }
        public int LightFlux { get; set; }
        public float Price { get; set; }

        public ICollection<LampBulbEntity> Lamps { get; set; }
    }
}