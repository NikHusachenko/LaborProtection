using LaborProtection.Calculation;
using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Calculation.Enums;
using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
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

        public int GetLampCount(RoomEntity roomEntity, LampEntity lampEntity, BulbEntity bulbEntity, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType)
        {
            double flux = LightFlux(roomEntity, lampEntity, floorReflection, wallReflection, ceillingReflection, lampType);
            return (int)Math.Round(flux / bulbEntity.LightFlux);
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

            return ResponseService<int>.Ok(GetJsonSection.GetValue($"{ceillingReflection}:{wallReflection}:{floorReflection}:{roomIndex}", jsonSource));
        }

        public double LampHeightSuspension(double roomHeight, double lampHeight, double tableHeight)
        {
            return roomHeight - tableHeight - lampHeight;
        }

        public double LightFlux(RoomEntity roomEntity, LampEntity lampEntity, double floorReflection, double wallReflection, double ceillingReflection, LampType lampType)
        {
            double roomIndex = RoomIndex(roomEntity, lampEntity);
            double nuy = GetUseCoefficient(roomIndex, floorReflection, wallReflection, ceillingReflection, lampType).Value;
            return (Light.E * Light.K * Light.Z * GetRoomArea(roomEntity)) / nuy;
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