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
                     |                                   |
                     |    __________________________     |
                     |    |                        |     |
                     |    |         TABLE          |     |       
                    W|    |                        |     |
                    I|    |________________________|     |
                    D|                                   |
                    T|                                   |
                    H|                                   |
                     |              WORK                 |
                     |              SPACE                |
                     |                                   |
                     |                                   |       VOLUME >= 20(^3)
                     |___________________________________|       AREA >= 6(^2)





        */
        public async Task<ResponseService<WorkSpaceEntity>> AddTable(WorkSpaceEntity workSpaceEntity, double tableWidth, double tableLength)
        {
            if (tableLength < Limitations.MINIMUM_TABLE_LENGTH ||
                tableWidth < Limitations.MINIMUM_TABLE_WIDTH)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            if (workSpaceEntity.Width -  LengthConverter.SantimettersToMetters(tableWidth) < Limitations.BETWEEB_MONITORS)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            if (workSpaceEntity.Length - LengthConverter.SantimettersToMetters(tableLength) < Limitations.BETWEEN_TABLES)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            TableEntity tableEntity = new TableEntity()
            {
                Length = tableLength,
                Width = tableWidth,
            };

            workSpaceEntity.Table = tableEntity;
            return ResponseService<WorkSpaceEntity>.Ok(workSpaceEntity);
        }

        public async Task<ResponseService<WorkSpaceEntity>> CalculateWorkSpace(double length, double width, double roomHeight)
        {
            double area = length * width;
            if (area < Limitations.MINIMAL_AREA)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            double volume = length * width * roomHeight;
            if (volume < Limitations.MINIMAL_VOLUME)
            {
                return ResponseService<WorkSpaceEntity>.Error();
            }

            return ResponseService<WorkSpaceEntity>.Ok(new WorkSpaceEntity()
            {
                Height = roomHeight,
                Length = length,
                Width = width,
            });
        }

        public async Task<ResponseService<int>> GetMinimaumSpacesInLength(double roomLength)
        {
            if (roomLength <= (LengthConverter.SantimettersToMetters(Limitations.MAXIMUM_TABLE_LENGTH) + Limitations.BETWEEN_TABLES))
            {
                return ResponseService<int>.Error();
            }

            double minimalWorkSpaceLength = LengthConverter.SantimettersToMetters(Limitations.MINIMUM_TABLE_LENGTH) + Limitations.BETWEEN_TABLES;
            int minimumWorkSpaceCount = (int)(roomLength / minimalWorkSpaceLength);

            return ResponseService<int>.Ok(minimumWorkSpaceCount);
        }

        public async Task<ResponseService<int>> GetMinimumSpacesInWidth(double roomWidth)
        {
            if (roomWidth <= (LengthConverter.SantimettersToMetters(Limitations.MINIMUM_TABLE_WIDTH) + Limitations.BETWEEB_MONITORS))
            {
                return ResponseService<int>.Error();
            }

            double minimalWorkSpaceWidth = LengthConverter.SantimettersToMetters(Limitations.MINIMUM_TABLE_WIDTH) + Limitations.BETWEEB_MONITORS;
            int minimumWorkSpaceCount = (int)(roomWidth / minimalWorkSpaceWidth);

            return ResponseService<int>.Ok(minimumWorkSpaceCount);
        }

        public async Task<ResponseService<int>> GetSpacesInLength(double roomLength, double tableLength)
        {
            if (roomLength <= (LengthConverter.SantimettersToMetters(Limitations.MAXIMUM_TABLE_LENGTH) + Limitations.BETWEEN_TABLES) || 
                tableLength < LengthConverter.SantimettersToMetters(Limitations.MINIMUM_TABLE_LENGTH))
            {
                return ResponseService<int>.Error();
            }

            var spaceLength = LengthConverter.SantimettersToMetters(tableLength) + Limitations.BETWEEN_TABLES;
            var spacesCount = (int)(roomLength / spaceLength);

            return ResponseService<int>.Ok(spacesCount);
        }

        public async Task<ResponseService<int>> GetSpacesInWidth(double roomWidth, double tableWidth)
        {
            if (roomWidth <= (LengthConverter.SantimettersToMetters(Limitations.MINIMUM_TABLE_WIDTH) + Limitations.BETWEEB_MONITORS) ||
                tableWidth < Limitations.MINIMUM_TABLE_WIDTH)
            {
                return ResponseService<int>.Error();
            }

            var spaceWidth = LengthConverter.SantimettersToMetters(tableWidth) + Limitations.BETWEEB_MONITORS;
            var spacesCount = (int)(roomWidth / spaceWidth);

            return ResponseService<int>.Ok(spacesCount);
        }

        public async Task<ResponseService<double>> GetWorkSpaceArea(double roomLength, double roomWidth, double tableLength, double tableWidth)
        {
            if (roomLength <= 0 ||
                roomWidth <= 0 ||
                tableLength < Limitations.MINIMUM_TABLE_LENGTH ||
                tableWidth < Limitations.MINIMUM_TABLE_WIDTH)
            {
                return ResponseService<double>.Error();
            }

            double spaceLength = LengthConverter.SantimettersToMetters(tableLength) + Limitations.BETWEEN_TABLES;
            double spaceWidth = LengthConverter.SantimettersToMetters(tableWidth) + Limitations.BETWEEB_MONITORS;

            return ResponseService<double>.Ok(spaceLength * spaceWidth);
        }

        public async Task<ResponseService<double>> GetWorkSpaceVolume(double roomLength, double roomWidth, double roomHeight, double tableLength, double tableWidth)
        {
            if (roomLength <= 0 ||
                roomWidth <= 0 ||
                roomHeight <= 0 ||
                tableLength < Limitations.MINIMUM_TABLE_LENGTH ||
                tableWidth < Limitations.MINIMUM_TABLE_WIDTH)
            {
                return ResponseService<double>.Error();
            }

            double spaceLength = LengthConverter.SantimettersToMetters(tableLength) + Limitations.BETWEEN_TABLES;
            double spaceWidth = LengthConverter.SantimettersToMetters(tableWidth) + Limitations.BETWEEB_MONITORS;

            return ResponseService<double>.Ok(spaceLength * spaceWidth * roomHeight);
        }

        public async Task<ResponseService<double>> ValidateAndGetVolume(WorkSpaceEntity workSpaceEntity)
        {
            // Refactoring

            if (workSpaceEntity.Width <= workSpaceEntity.Table.Width ||
                workSpaceEntity.Length <= workSpaceEntity.Table.Length)
            {
                return ResponseService<double>.Error();
            }

            double volume = workSpaceEntity.Length * workSpaceEntity.Width * workSpaceEntity.Height;

            if (volume < Limitations.MINIMAL_VOLUME)
            {
                return ResponseService<double>.Error();
            }
            return ResponseService<double>.Ok(volume);
        }
    }
}