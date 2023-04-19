namespace LaborProtection.Calculation.Entities
{
    public class WorkSpaceEntity
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }

        public TableEntity Table { get; set; }
    }
}