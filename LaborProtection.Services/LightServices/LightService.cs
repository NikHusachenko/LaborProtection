using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;

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
    }
}