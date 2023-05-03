using LaborProtection.Database.Entities;
using LaborProtection.Services.BulbServices.Models;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.BulbServices
{
    public interface IBulbService
    {
        Task<ResponseService<long>> Create(CreateBulbPostModel vm);
        Task<ResponseService> Delete(long id);
        Task<ResponseService> Update(BulbEntity bulbEntity);

        Task<ResponseService<BulbEntity>> GetById(long id);
        Task<ResponseService<BulbEntity>> GetByName(string name);

        Task<ICollection<BulbEntity>> GetAll();
    }
}