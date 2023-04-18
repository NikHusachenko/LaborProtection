using LaborProtection.Database.Entities;
using LaborProtection.Services.LampServices.Models;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.LampServices
{
    public interface ILampService
    {
        Task<ResponseService<long>> Create(CreateLampPostModel vm);
        Task<ResponseService> Delete(long id);
        Task<ResponseService> Update(LampEntity lampEntity);

        Task<ResponseService<LampEntity>> GetById(long id);

        Task<ICollection<LampEntity>> GetAll();
    }
}