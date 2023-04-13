namespace LaborProtection.Services.LampServices.Models
{
    public class CreateLampPostModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public float Price { get; set; }
        public ushort BulbCount { get; set; }
        public float Height { get; set; }
    }
}