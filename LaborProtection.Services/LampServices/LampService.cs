using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.EntityFramework.Repository;
using LaborProtection.Services.LampServices.Models;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.LampServices
{
    public class LampService : ILampService
    {
        private readonly IGenericRepository<LampEntity> _lampRepository;

        public LampService(IGenericRepository<LampEntity> lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public async Task<ResponseService<long>> Create(CreateLampPostModel vm)
        {
            LampEntity dbRecord = await _lampRepository.GetBy(lamp => lamp.Name == vm.Name);
            if (dbRecord != null)
            {
                return ResponseService<long>.Error(Errors.WAS_CREATED_ERROR);
            }

            if (!Enum.IsDefined(typeof(LampType), vm.Type))
            {
                return ResponseService<long>.Error(Errors.INVALID_LAMP_TYPE_ERROR);
            }

            LampEntity newRecord = new LampEntity()
            {
                BulbCount = vm.BulbCount,
                Height = vm.Height,
                Name = vm.Name,
                Price = vm.Price,
                Type = (LampType)vm.Type,
            };

            await _lampRepository.Create(newRecord);
            return ResponseService<long>.Ok(newRecord.Id);
        }
    }
}