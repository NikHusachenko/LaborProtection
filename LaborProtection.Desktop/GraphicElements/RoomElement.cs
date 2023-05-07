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
	public class RoomElement<T>
		where T : class
	{
		public Rectangle RoomRectangle { get; set; }
		public RoomElement(RoomEntity room, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, int? elementNumberWidth, Canvas canvas)
		{

			CreateRoom(room, transponeServiceWidth, transponeServiceHeight, elementNumberLenght, elementNumberWidth, canvas);
		}

		private void CreateRoom(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, int? elementNumberWidth, Canvas canvas)
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
				double elementLenghtMeters = roomEntity.Length / elementNumberLenght; // Length of one element
				double elementWidthMeters = roomEntity.Width / elementNumberLenght; // Width of one element

				//double lampsNumberLenght = Math.Ceiling(roomEntity.Length / elementLenghtMeters);
				//double lampsNumberWidth = Math.Ceiling(elementNumberLenght / lampsNumberLenght);
				int elementsPerRow = (int)Math.Floor(roomEntity.Length / elementLenghtMeters);
				int elementsPerColumn = (int)Math.Floor(roomEntity.Width / elementWidthMeters);

				for (int i = 0; i < elementsPerRow; i++)
				{
					for (int j = 0; j < elementsPerColumn; j++)
					{
						new LampElement(elementLenghtMeters, elementWidthMeters, transponeServiceWidth, transponeServiceHeight, canvas,
							i * transponeServiceWidth.ConditionalUnit * elementLenghtMeters,
							j * transponeServiceHeight.ConditionalUnit * elementWidthMeters);
					}
				}
			}
			canvas.Children.Add(RoomRectangle);
		}
	}
	//public class RoomElement
	//{
	//	public Rectangle RoomRectangle { get; set; }
	//	public RoomElement(RoomEntity room, TransponeService transponeServiceWidth,TransponeService transponeServiceHeight,int tableNumberLenght,int tableNumberWidth,Canvas canvas)//int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
	//	{
	//		CreateRoom(room, transponeServiceWidth,transponeServiceHeight, tableNumberLenght,tableNumberWidth, canvas);
	//	}

	//	private void CreateRoom(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
	//	{
	//		RoomRectangle = new Rectangle
	//		{
	//			Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
	//			Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
	//			Stroke = Brushes.Black,
	//		};

	//		for (int i = 0; i < tableNumberWidth; i++)
	//		{
	//			for (int j = 0; j < tableNumberHeight; j++)
	//			{
	//				new WorkSpaceElement(roomEntity.WorkSpace,transponeServiceWidth, transponeServiceHeight, canvas,
	//					 i * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width, // SetLeft
	//					 j * transponeServiceHeight.ConditionalUnit * roomEntity.WorkSpace.Length); // SetTop
	//			}
	//		}
	//		canvas.Children.Add(RoomRectangle);
	//	}
	//}
}
