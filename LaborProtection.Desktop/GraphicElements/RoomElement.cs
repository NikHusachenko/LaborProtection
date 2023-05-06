using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.TransponeServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
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
		public RoomElement(RoomEntity room, TransponeService transponeServiceWidth,TransponeService transponeServiceHeight,int elementNumberLenght,int elementNumberWidth,Canvas canvas)
		{

			CreateRoom(room, transponeServiceWidth,transponeServiceHeight, elementNumberLenght,elementNumberWidth, canvas);
		}

		private void CreateRoom(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int elementNumberLenght, int elementNumberWidth,Canvas canvas)
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
					if(typeof(T) == typeof(WorkSpaceElement))
			        {
						new WorkSpaceElement(roomEntity.WorkSpace, transponeServiceWidth, transponeServiceHeight, canvas,
							 i * transponeServiceWidth.ConditionalUnit * roomEntity.WorkSpace.Width, // SetLeft
							 j * transponeServiceHeight.ConditionalUnit * roomEntity.WorkSpace.Length); // SetTop
				    }
					else if(typeof(T) == typeof(LampElement))
					{
						new LampElement(transponeServiceWidth, transponeServiceHeight, canvas,
							i * transponeServiceWidth.ConditionalUnit * Limitations.DEFAULT_LAMP_SPACE_WIDTH,
							j * transponeServiceHeight.ConditionalUnit * Limitations.DEFAULT_LAMP_SPACE_HEIGHT);

					}
			    }
			}
			canvas.Children.Add(RoomRectangle);
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
