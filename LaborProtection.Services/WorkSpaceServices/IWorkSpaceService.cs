using LaborProtection.Calculation.Entities;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.WorkSpaceServices
{
    public interface IWorkSpaceService
    {
        Task<ResponseService<int>> GetMinimaumSpacesInLength(double roomLength);
        Task<ResponseService<int>> GetSpacesInLength(double roomLength, double tableLength);
        Task<ResponseService<int>> GetMinimumSpacesInWidth(double roomWidth);
        Task<ResponseService<int>> GetSpacesInWidth(double roomWidth, double tableWidth);
        Task<ResponseService<double>> GetWorkSpaceVolume(double roomLength, double roomWidth, double roomHeight, double tableLength, double tableWidth);
        Task<ResponseService<double>> GetWorkSpaceArea(double roomLength, double roomWidth, double tableLength, double tableWidth);

        Task<ResponseService<WorkSpaceEntity>> CalculateWorkSpace(double length, double width, double roomHeight);
        Task<ResponseService<WorkSpaceEntity>> AddTable(WorkSpaceEntity workSpaceEntity, double tableWidth, double tableLength);
        Task<ResponseService<double>> ValidateAndGetVolume(WorkSpaceEntity workSpaceEntity);
    }
}