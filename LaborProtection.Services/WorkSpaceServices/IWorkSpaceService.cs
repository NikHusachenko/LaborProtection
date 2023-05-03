using LaborProtection.Calculation.Entities;
using LaborProtection.Services.Response;

namespace LaborProtection.Services.WorkSpaceServices
{
    public interface IWorkSpaceService
    {
        Task<ResponseService<WorkSpaceEntity>> GetWorkSpace(double roomLength, double roomWidth, double roomHeight, double tableLength, double tableWidth);

        int GetWorkSpacesInLegth(double workspaceLength, double roomLength);
        int GetWorkSpacesInWidth(double workspaceWidth, double roomWidth);

        Task<ResponseService<double>> ValidateArea(double length, double width);
        Task<ResponseService<double>> ValidateVolume(double length, double width, double height);
    }
}