using LaborProtection.Calculation;
using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Calculation.Enums;
using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.EntityFramework.Repository;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.Response;
using LaborProtection.Services.WorkSpaceServices.Helpers;

namespace LaborProtection.Services.LightServices
{
    public class LightService : ILightService
    {
        private readonly ILampService _lampService;
        private readonly IBulbService _bulbService;

        public LightService(ILampService lampService,
            IBulbService bulbService)
        {
            _lampService = lampService;
            _bulbService = bulbService;
        }

        public async Task<ResponseService<int>> GetLampCount(RoomEntity roomEntity, LampEntity lampEntity, BulbEntity bulbEntity, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType)
        {
            var response = await LightFlux(roomEntity, lampEntity, floorReflection, wallReflection, ceillingReflection, lampType);
            if (response.IsError)
            {
                return ResponseService<int>.Error(response.ErrorMessage);
            }

            int bulbCount = (int)Math.Ceiling(response.Value / bulbEntity.LightFlux);
            int lampCount = (int)(bulbCount / lampEntity.BulbCount);

            return ResponseService<int>.Ok(lampCount);
        }

        public ResponseService<int> GetUseCoefficient(double roomIndex, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType)
        {
            JsonSource jsonSource = 0;

            switch (lampType)
            {
                case LampType.LPO:
                case LampType.OD:
                    {
                        jsonSource = JsonSource.LPO;
                        break;
                    }
                case LampType.LSP:
                case LampType.LSO:
                    {
                        jsonSource = JsonSource.LSP;
                        break;
                    }
                default:
                    {
                        return ResponseService<int>.Error(Errors.UNKNOWN_LAMP_TYPE_ERROR);
                    }
            }

            int useCoefficient = GetJsonSection.GetValue($"{ceillingReflection}:{wallReflection}:{floorReflection}:{roomIndex}", jsonSource);
            if (useCoefficient < 0)
            {
                return ResponseService<int>.Error(Errors.INVALID_REFLECTION_VALUES_ERROR);
            }

            return ResponseService<int>.Ok(useCoefficient);
        }

        public double LampHeightSuspension(double roomHeight, double lampHeight, double tableHeight)
        {
            return roomHeight - tableHeight - lampHeight;
        }

        public async Task<ResponseService<double>> LightFlux(RoomEntity roomEntity, LampEntity lampEntity, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType)
        {
            double roomIndex = RoomIndex(roomEntity, lampEntity);

            var response = GetUseCoefficient(roomIndex, floorReflection, wallReflection, ceillingReflection, lampType);
            if (response.IsError)
            {
                return ResponseService<double>.Error(response.ErrorMessage);
            }

            double top = Light.E * Light.K * Light.Z * GetRoomArea(roomEntity);
            double bottom = (response.Value / 100.0);

            double lightFlux = top / bottom;
            return ResponseService<double>.Ok(lightFlux);
        }

        public double RoomIndex(RoomEntity roomEntity, LampEntity lampEntity)
        {
            double lampHeightSuspension = LampHeightSuspension(roomEntity.Height, 
                LengthConverter.MillimetreToMetters(lampEntity.Height), 
                LengthConverter.SantimettersToMetters(roomEntity.WorkSpace.Table.Height));

            double roomArea = GetRoomArea(roomEntity);

            return roomArea / (lampHeightSuspension * (roomEntity.Width + roomEntity.Length));
        }

        private double GetRoomArea(RoomEntity roomEntity)
        {
            return roomEntity.Length * roomEntity.Width;
        }
    }
}