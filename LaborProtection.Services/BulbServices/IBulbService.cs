using LaborProtection.Services.BulbServices.Models;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.BulbServices
{
    public interface IBulbService
    {
        Task<ResponseService<long>> Create(CreateBulbPostModel vm);
    }
}