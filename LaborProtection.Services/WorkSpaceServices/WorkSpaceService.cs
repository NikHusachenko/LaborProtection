using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.Response;
using LaborProtection.Services.WorkSpaceServices.Helpers;

namespace LaborProtection.Services.WorkSpaceServices
{
    public class WorkSpaceService : IWorkSpaceService
    {
        /*



                                   LENGTH
                     _____________________________________
                     |  |                                |
                     |  |  __________________________    |      1.2m
                     |  |  |                        |    |  ------------>
                     |  |  |         TABLE          |    |       
                   W |  |  |                        |    |
                   I |  |  |________________________|    |
                   D |  |                                |
                   T |  | 2.5m                           |
                   H |  |                                |
                     |  |            WORK                |
                     |  |            SPACE               |
                     |  |                                |
                     |  |                                |       VOLUME >= 20(^3)
                     |__V________________________________|       AREA >= 6(^2)

                                        

                        WINDTH >= 2.5m
                        LENGTH >= TABLE LENGTH


        */
        public async Task<ResponseService<WorkSpaceEntity>> GetWorkSpace(double roomLength, double roomWidth, double roomHeight, double tableLength, double tableWidth)
        {
            if (roomLength < 0 || 
                roomWidth < 0 ||
                LengthConverter.SantimettersToMetters(tableLength) > roomLength ||
                LengthConverter.SantimettersToMetters(tableWidth) > roomWidth)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            double minimalArea = Limitations.MINIMAL_VOLUME / roomHeight;
            double spaceWidth = Limitations.MINIMAL_WIDTH;
            double spaceLength = minimalArea / spaceWidth;

            if (spaceWidth < LengthConverter.SantimettersToMetters(tableLength) + Limitations.BETWEEN_TABLES)
            {
                spaceWidth = LengthConverter.SantimettersToMetters(tableLength) + Limitations.BETWEEN_TABLES;
            }

            return ResponseService<WorkSpaceEntity>.Ok(new WorkSpaceEntity()
            {
                Height = roomHeight,
                Length = spaceLength,
                Width = spaceWidth,
                Table = new TableEntity()
                {
                    Length = tableLength,
                    Width = tableWidth,
                },
            });
        }

        public int GetWorkSpacesInLegth(double workspaceLength, double roomLength)
        {
            int value = (int)Math.Floor(roomLength / workspaceLength);
            return value;
        }

        public int GetWorkSpacesInWidth(double workspaceWidth, double roomWidth)
        {
            int value = (int)Math.Floor(roomWidth / workspaceWidth);
            return value;
        }

        public async Task<ResponseService<double>> ValidateArea(double length, double width)
        {
            double area = length * width;

            if (area < Limitations.MINIMAL_AREA)
            {
                return ResponseService<double>.Error();
            }
            return ResponseService<double>.Ok(area);
        }

        public async Task<ResponseService<double>> ValidateVolume(double length, double width, double height)
        {
            double volume = length * width * height;

            if (volume < Limitations.MINIMAL_VOLUME)
            {
                return ResponseService<double>.Error();
            }
            return ResponseService<double>.Ok(volume);
        }
    }
}