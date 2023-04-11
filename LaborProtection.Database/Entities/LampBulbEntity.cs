namespace LaborProtection.Database.Entities
{
    public class LampBulbEntity
    {
        public long LampFK { get; set; }
        public LampEntity Lamp { get; set; }

        public long BulbFK { get; set; }
        public BulbEntity Bulb { get; set; }
    }
}