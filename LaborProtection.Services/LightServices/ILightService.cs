﻿using LaborProtection.Calculation.Entities;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.LightServices
{
    public interface ILightService
    {
        Task<ResponseService<int>> GetLampCount(RoomEntity roomEntity, LampEntity lampEntity, BulbEntity bulbEntity, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType);
        Task<ResponseService<double>> LightFlux(RoomEntity roomEntity, LampEntity lampEntity, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType);
        double RoomIndex(RoomEntity roomEntity, LampEntity lampEntity);
        double LampHeightSuspension(double roomHeight, double lampHeight, double tableHeight);
        ResponseService<int> GetUseCoefficient(double roomIndex, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType);
    }
}