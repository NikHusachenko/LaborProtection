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
			//double scaleLength = 1;
			//double scaleWidth = 1;
			//RoomRectangle = new Rectangle
			//{
			//	Width = transponeServiceLength.ConditionalUnit * roomEntity.Length,
			//	Height = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
			//	Stroke = Brushes.Black,
			//};

			//double lenght = transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length * scaleLength * elementNumberLenght;
			//double width = transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width * scaleWidth * elementNumberWidth;
			//double sizeAspLengToWid = roomEntity.WorkSpace.Length / roomEntity.WorkSpace.Width;
			//double sizeAspWidToLeng = roomEntity.WorkSpace.Width / roomEntity.WorkSpace.Length;
			//double a;
			//double b;
			//double aspectRatio = roomEntity.WorkSpace.Length / roomEntity.WorkSpace.Width;

			//while (RoomRectangle.Width > transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length * scaleLength * elementNumberLenght
			// && RoomRectangle.Height > transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width * scaleWidth * elementNumberWidth)
			//{
			//	if (aspectRatio < 1)
			//	{
			//		roomEntity.WorkSpace.Width += 0.0001;
			//		roomEntity.WorkSpace.Length += 0.0001 * aspectRatio;
			//	}
			//	else
			//	{
			//		roomEntity.WorkSpace.Length += 0.0001;
			//		roomEntity.WorkSpace.Width += 0.0001 / aspectRatio;
			//	}
			//}


			//a = transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length * scaleLength * elementNumberLenght;
			//b = transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width * scaleWidth * elementNumberWidth;

			//if(a < b)
			//{
			//            roomEntity.WorkSpace.Length += 0.00001 * sizeAspLengToWid;
			//roomEntity.WorkSpace.Width += 0.00001 * sizeAspWidToLeng;
			//}
			//if (a > b)
			//{
			//	roomEntity.WorkSpace.Length += 0.00001 * sizeAspWidToLeng;
			//	roomEntity.WorkSpace.Width += 0.00001 *  sizeAspLengToWid;

			//}


			double scale = 1;

			RoomRectangle = new Rectangle
			{
				Width = transponeServiceLength.ConditionalUnit * roomEntity.Length,
				Height = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Stroke = Brushes.Black,
			};

            if(elementNumberWidth < elementNumberLenght)
			{
				while (RoomRectangle.Width > transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length * scale * elementNumberLenght)
				{
					scale += 0.00001;
					//roomEntity.WorkSpace.Length += 0.0001;
				}
			}
			for (int i = 0; i < elementNumberLenght; i++)
			{
				for (int j = 0; j < elementNumberWidth; j++)
				{
					new WorkSpaceElement(roomEntity.WorkSpace, transponeServiceLength, transponeServiceWidth, canvas,scale,
					i * transponeServiceLength.ConditionalUnit * roomEntity.WorkSpace.Length, // SetLeft
					j * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width); // SetTop
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
