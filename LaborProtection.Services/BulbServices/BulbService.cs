using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.EntityFramework.Repository;
using LaborProtection.Services.BulbServices.Models;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.BulbServices
{
    public class BulbService : IBulbService
    {
        private readonly IGenericRepository<BulbEntity> _bulbRepository;

        public BulbService(IGenericRepository<BulbEntity> bulbRepository)
        {
            _bulbRepository = bulbRepository;
        }

        public async Task<ResponseService<long>> Create(CreateBulbPostModel vm)
        {
            BulbEntity dbRecord = await _bulbRepository.GetBy(bulb => bulb.Name == vm.Name);
            if (dbRecord != null)
            {
                return ResponseService<long>.Error(Errors.WAS_CREATED_ERROR);
            }

            dbRecord = new BulbEntity()
            {
                LightFlux = vm.LightFlux,
                Name = vm.Name,
                Power = vm.Power,
                Price = vm.Price,
                Type = (BulbType)vm.Type,
                Voltage = vm.Voltage,
            };

            try
            {
                await _bulbRepository.Create(dbRecord);
                return ResponseService<long>.Ok(dbRecord.Id);
            }
            catch (Exception ex)
            {
                return ResponseService<long>.Error($"LOG: BulbService -> Create exception: {ex.Message}");
            }
        }
    }
}