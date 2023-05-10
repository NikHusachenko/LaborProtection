using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.TransponeServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class RoomElement
	{
		public Rectangle RoomRectangle { get; set; }
		public RoomElement(RoomEntity room, TransponeService transponeServiceLength, TransponeService transponeServiceWidth, int elementNumberLenght, int elementNumberWidth, Canvas canvas)
		{
			CreateRoomWithWorkSpaces(room, transponeServiceLength, transponeServiceWidth, elementNumberLenght, elementNumberWidth, canvas);
		}
		public RoomElement(RoomEntity room, TransponeService transponeServiceLength, TransponeService transponeServiceWidth, int elementNumber, Canvas canvas)
		{
			CreateRoomWithLamps(room, transponeServiceLength, transponeServiceWidth, elementNumber, canvas);
		}
		private void CreateRoomWithWorkSpaces(RoomEntity roomEntity, TransponeService transponeServiceLength, TransponeService transponeServiceWidth, int elementNumberLenght, int elementNumberWidth, Canvas canvas)
		{
			double scaleLength = 1;
		    double scaleWidth= 1;
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceLength.ConditionalUnit * roomEntity.Length,
				Height = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Stroke = Brushes.Black,
			};
			while (RoomRectangle.Width > transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length * scaleLength * elementNumberLenght)
			{
				double a = transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length * scaleLength * elementNumberLenght;
				scaleLength += 0.00001;
			}
			while (RoomRectangle.Height > transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width * scaleWidth * elementNumberWidth)
			{
				double b = transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width * scaleWidth * elementNumberWidth;
				scaleWidth += 0.00001;
			}
			for (int i = 0; i < elementNumberLenght; i++)
			{
				for (int j = 0; j < elementNumberWidth; j++)
				{
					new WorkSpaceElement(roomEntity.WorkSpace, transponeServiceLength, transponeServiceWidth, canvas, scaleLength, scaleWidth,
					i * transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length  * scaleLength, // SetLeft
					j * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width * scaleWidth); // SetTop
				}
			}
			canvas.Children.Add(RoomRectangle);
		}
		private void CreateRoomWithLamps(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumber, Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceWidth.ConditionalUnit * roomEntity.Length,
				Height = transponeServiceHeight.ConditionalUnit * roomEntity.Width,
				Stroke = Brushes.Black,
			};

			int numElements = elementNumber;
			double roomLength = RoomRectangle.Width;
			double roomWidth = RoomRectangle.Height;
			double sizeRatio = 2;
			double roomArea = roomLength * roomWidth;
			double eachElementArea = roomArea / numElements;
			double elementLength = Math.Sqrt(eachElementArea / sizeRatio);
			double elementWidth = (sizeRatio * elementLength);
			int numCols = (int)(RoomRectangle.Width / elementLength);
			int numRows = (int)(RoomRectangle.Height / elementWidth);

			int allRows = numRows + 1;
			while (roomWidth < elementWidth * allRows)
			{
				elementWidth -= 0.01;
			}
			while (roomLength < elementLength * numCols + elementLength / 4)
			{
				elementLength -= 0.01;
			}
			int remainderElements = numElements - numCols * numRows;
			double remainderScale = numCols / (double)remainderElements;
			for (int i = 0; i < numCols; i++)
			{
				for (int j = 0; j < numRows; j++)
				{
					new LampElement(elementLength, elementWidth, transponeServiceWidth, transponeServiceHeight, canvas,
						i * elementLength + elementLength / 2,
						j * elementWidth + elementWidth / 2);
				}
			}
			for (int k = 0; k < remainderElements; k++)
			{
				new LampElement(elementLength, elementWidth, transponeServiceWidth, transponeServiceHeight, canvas,
						k * elementLength * remainderScale + elementLength / 2,
						numRows * elementWidth + elementWidth / 2);
			}

			canvas.Children.Add(RoomRectangle);
		}
	}
}
