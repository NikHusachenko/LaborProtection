using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.TransponeServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
using Microsoft.Identity.Client;
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
		public RoomElement(RoomEntity room, TransponeService transponeServiceWidth,TransponeService transponeServiceHeight,int elementNumberLenght,int elementNumberWidth,Canvas canvas)
		{
			CreateRoomWithWorkSpaces(room, transponeServiceWidth,transponeServiceHeight, elementNumberLenght,elementNumberWidth, canvas);
		}
		public RoomElement(RoomEntity room, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, Canvas canvas)
		{
			CreateRoomWithLamps(room, transponeServiceWidth, transponeServiceHeight, elementNumberLenght, canvas);
		}
		private void CreateRoomWithWorkSpaces(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, int elementNumberWidth,Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
				Stroke = Brushes.Black,
			};

				for (int i = 0; i < elementNumberLenght; i++)
				{
					for (int j = 0; j < elementNumberWidth; j++)
					{
						new WorkSpaceElement(roomEntity.WorkSpace, transponeServiceWidth, transponeServiceHeight, canvas,
						i * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width, // SetLeft
						j * transponeServiceHeight.ConditionalUnit * roomEntity.WorkSpace.Length); // SetTop
					}
				}
			canvas.Children.Add(RoomRectangle);
		}
		private void CreateRoomWithLamps(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
				Stroke = Brushes.Black,
			};


			int numElements = elementNumberLenght;
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
						i * elementLength + elementLength / 5,
						j * elementWidth);
				}
			}
			for (int k = 0; k < remainderElements; k++)
			{
				new LampElement(elementLength, elementWidth, transponeServiceWidth, transponeServiceHeight, canvas,
						k * elementLength * remainderScale + elementLength / 5,
						numRows * elementWidth);//
			}

			canvas.Children.Add(RoomRectangle);
		}
	}
}
