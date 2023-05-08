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
	public class RoomElement<T> 
		where T : class
	{
		public Rectangle RoomRectangle { get; set; }
		public RoomElement(RoomEntity room, TransponeService transponeServiceWidth,TransponeService transponeServiceHeight,int elementNumberLenght,int? elementNumberWidth,Canvas canvas)
		{

			CreateRoom(room, transponeServiceWidth,transponeServiceHeight, elementNumberLenght,elementNumberWidth, canvas);
		}

		private void CreateRoom(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, int? elementNumberWidth,Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
				Stroke = Brushes.Black,
			};

			if (typeof(T) == typeof(WorkSpaceElement))
			{
				for (int i = 0; i < elementNumberLenght; i++)
				{
					for (int j = 0; j < elementNumberWidth; j++)
					{
						new WorkSpaceElement(roomEntity.WorkSpace, transponeServiceWidth, transponeServiceHeight, canvas,
						i * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width, // SetLeft
						j * transponeServiceHeight.ConditionalUnit * roomEntity.WorkSpace.Length); // SetTop
					}
				}

			}
			else if (typeof(T) == typeof(LampElement))
			{
				//double roomLength = roomEntity.Length;
				//double roomWidth = roomEntity.Width;

				//double elementWidthToLenghtRation = 2;
				//int numElements = elementNumberLenght;

				//double roomArea = roomLength * roomWidth;
				//double lampSpaceLenght = Math.Sqrt(roomArea / (3 + Math.Floor((double)numElements / (double)Math.Floor(roomLength / Math.Sqrt(roomArea)))));
				//double lampSpaceWidth = lampSpaceLenght * elementWidthToLenghtRation;


				//int numColumns = (int)Math.Floor(roomWidth / lampSpaceWidth);//4
				//int numRows = (int)Math.Ceiling((double)numElements / numColumns);//9

				//				int numElementsPerRow = (int)Math.Ceiling((double)numElements / numRows);


				int numElements = elementNumberLenght;
				double roomLength = RoomRectangle.Width;
				double roomWidth = RoomRectangle.Height;
				double sizeRatio = 2;
				double roomArea = roomLength * roomWidth;

				double scaleLenght = 1;
				double scaleWidth = 1;
				// Calculate the target area of each element
				double targetArea = roomArea / numElements;
				// Solve for the length and width of each element based on the size ratio
				int elementLength = (int)Math.Sqrt(targetArea / sizeRatio);
				int elementWidth = (int)(sizeRatio * elementLength);

				int numCols =(int) RoomRectangle.Width / elementLength;
				int numRows =(int) RoomRectangle.Height / elementWidth;

				int remainderElements = numElements - numCols * numRows;
				int lastIterationI = 0;
				int lastIterationY = 0;
				

				for (int i = 0; i < numCols; i++)
				{
					
					for (int j = 0; j < numRows; j++)
					{

						if(numElements < 10)
						{
							scaleLenght = 1.05;
							scaleWidth = 1.7;
						}
						else if(numElements >10 && numElements < 100)
						{
							scaleLenght = 1.00;
							scaleWidth = 1.08;
						}
						else if(numElements > 100)
						{
							scaleLenght = 1;
							scaleWidth = 1;
						}
						//setLeft +=  elementLength / 2;
						//setTop += elementWidth / 2;
						
						lastIterationY++;
						new LampElement(elementLength, elementWidth, transponeServiceWidth, transponeServiceHeight, canvas,
							i * elementLength * scaleLenght ,//ЗАдати відстані між лампами щоб воно рівномірно по кімнаті роїхалося
							j * elementWidth * scaleWidth);//
					}
					lastIterationI++;
				}
				for(int k = 0; k < remainderElements; k++)
				{
					new LampElement(elementLength, elementWidth, transponeServiceWidth, transponeServiceHeight, canvas,
							k  * elementLength * scaleLenght ,//ЗАдати відстані між лампами щоб воно рівномірно по кімнаті роїхалося
							numRows * elementWidth * scaleWidth);//
				}



			}
			canvas.Children.Add(RoomRectangle);
		}
		private static double GetCanvasCordination(int iter, double elementParameter, double scale)
		{
			return iter * elementParameter * scale;
		}
		//private void CreateRoom(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, int elementNumberWidth, Canvas canvas)
		//{
		//	RoomRectangle = new Rectangle
		//	{
		//		Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
		//		Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
		//		Stroke = Brushes.Black,
		//	};

		//	for (int i = 0; i < elementNumberLenght; i++)
		//	{
		//		for (int j = 0; j < elementNumberWidth; j++)
		//		{
		//			if (typeof(T) == typeof(WorkSpaceElement))
		//			{
		//				new WorkSpaceElement(roomEntity.WorkSpace, transponeServiceWidth, transponeServiceHeight, canvas,
		//					 i * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width, // SetLeft
		//					 j * transponeServiceHeight.ConditionalUnit * roomEntity.WorkSpace.Length); // SetTop
		//			}
		//			else if (typeof(T) == typeof(LampElement))
		//			{
		//				//new LampElement()
		//			}
		//		}
		//	}
		//	canvas.Children.Add(RoomRectangle);
		//}
	}
}
