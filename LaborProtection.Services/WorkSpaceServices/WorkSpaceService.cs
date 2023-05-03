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
        public ResponseService<RoomEntity> GetRoom(double roomLength, double roomWidth, double roomHeight, WorkSpaceEntity workSpace)
        {
            if (roomLength < LengthConverter.SantimettersToMetters(workSpace.Table.Length) + Limitations.BETWEEN_TABLES ||
                roomWidth < Limitations.MINIMAL_WIDTH)
            {
                return ResponseService<RoomEntity>.Error();
            }

            RoomEntity roomEntity = new RoomEntity()
            {
                Height = roomHeight,
                Length = roomLength,
                Width = roomWidth,
            };

            int spacesInLength = GetWorkSpacesInLegth(workSpace.Length, roomLength);
            int spacesInWidth = GetWorkSpacesInWidth(workSpace.Width, roomWidth);

            try
            {
                roomEntity.WorkSpaces = new WorkSpaceEntity[spacesInLength, spacesInWidth];
            }
            catch (Exception ex)
            {
                return ResponseService<RoomEntity>.Error();
            }

            for (int i = 0; i < spacesInLength; i++)
            {
                for (int j = 0; j < spacesInWidth; j++)
                {
                    roomEntity.WorkSpaces[i, j] = new WorkSpaceEntity()
                    {
                        Height = workSpace.Height,
                        Length = workSpace.Length,
                        Width = workSpace.Width,
                        Table = new TableEntity()
                        {
                            Length = workSpace.Table.Length,
                            Width = workSpace.Table.Width,
                        },
                    };
                }
            }

            return ResponseService<RoomEntity>.Ok(roomEntity);
        }

        public async Task<ResponseService<WorkSpaceEntity>> GetWorkSpace(double roomHeight, double tableLength, double tableWidth)
        {
            if (LengthConverter.SantimettersToMetters(tableLength) < 0 ||
                LengthConverter.SantimettersToMetters(tableWidth) < 0)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            double minimalArea = Math.Round(Limitations.MINIMAL_VOLUME / roomHeight, 2);

            if (minimalArea < Limitations.MINIMAL_AREA)
            {
                minimalArea = Limitations.MINIMAL_AREA;
            }

            double spaceWidth = Limitations.MINIMAL_WIDTH;
            double spaceLength = Math.Round(minimalArea / spaceWidth, 2);

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