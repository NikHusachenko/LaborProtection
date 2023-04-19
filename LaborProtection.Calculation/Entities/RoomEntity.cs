﻿namespace LaborProtection.Calculation.Entities
{
    public class RoomEntity
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public ICollection<WorkSpaceEntity> WorkSpaces { get; set; }
    }
}