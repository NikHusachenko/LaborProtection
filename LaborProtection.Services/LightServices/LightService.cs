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

            int count = (int)Math.Round(response.Value / bulbEntity.LightFlux);
            return ResponseService<int>.Ok(count);
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

            return ResponseService<double>.Ok(Light.E * Light.K * Light.Z * GetRoomArea(roomEntity) / response.Value);
        }

        public double RoomIndex(RoomEntity roomEntity, LampEntity lampEntity)
        {
            double lampHeightSuspension = LampHeightSuspension(roomEntity.Height, lampEntity.Height, roomEntity.WorkSpace.Table.Height);
            double roomArea = GetRoomArea(roomEntity);

            return roomArea / (lampHeightSuspension * (roomEntity.Width + roomEntity.Length));
        }

        private double GetRoomArea(RoomEntity roomEntity)
        {
            return roomEntity.Length * roomEntity.Height * roomEntity.Width;
        }
    }
}