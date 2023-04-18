using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.EntityFramework.Repository;
using LaborProtection.Services.LampServices.Models;
using LaborProtection.Services.Response;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            if (!Directory.Exists(Configuration.STATIC_FOLDER))
            {
                Directory.CreateDirectory(Configuration.STATIC_FOLDER);
            }

            string imageExtenstion = vm.Image.Name.Split('.')[vm.Image.Name.Split('.').Length - 1];
            string pathToSave = $"{Configuration.STATIC_FOLDER}{vm.Name}.{imageExtenstion}";
            
            try
            {
                vm.Image.CopyTo(pathToSave);
            }
            catch (Exception ex)
            {
                return ResponseService<long>.Error($"LOG: LampService -> Create exception: {ex.Message}");
            }

            LampEntity newRecord = new LampEntity()
            {
                BulbCount = vm.BulbCount,
                Height = vm.Height,
                Name = vm.Name,
                Price = vm.Price,
                Type = (LampType)vm.Type,
                ImagePath = pathToSave,
            };

            try
            {
                await _lampRepository.Create(newRecord);
                return ResponseService<long>.Ok(newRecord.Id);
            }
            catch (Exception ex)
            {
                return ResponseService<long>.Error($"LOG: LampService -> Create exception: {ex.Message}");
            }
        }

        public async Task<ICollection<LampEntity>> GetAll()
        {
            return await _lampRepository.GetAll()
                .ToListAsync();
        }

        public async Task<ResponseService<LampEntity>> GetById(long id)
        {
            var dbRecord = await _lampRepository.GetById(id);
            if (dbRecord == null)
            {
                return ResponseService<LampEntity>.Error(Errors.NOT_FOUNT_ERROR);
            }
            else
            {
                return ResponseService<LampEntity>.Ok(dbRecord);
            }
        }
    }
}