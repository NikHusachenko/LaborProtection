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
	public class RoomElement
	{
		//public RoomEntity _roomEntity;
		public WorkSpaceElement[,] tables { get; set; }
		public Rectangle RoomRectangle { get; set; }
		//private TransponeService TransponeServiceWidth { get; set; }
		//private TransponeService TransponeServiceHeight { get; set; }

		public RoomElement(RoomEntity room,TransponeService transponeServiceWidth,TransponeService transponeServiceHeight,int tableNumberLenght,int tableNumberWidth,Canvas canvas)//int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			//_roomEntity = room;
			//TransponeServiceWidth = new TransponeService(room.Width,canvas.ActualWidth);//roomWidth, canvas.ActualWidth);
			//TransponeServiceHeight = new TransponeService(room.Length,canvas.ActualHeight);// roomHeight, canvas.ActualHeight);
		
			tables = new WorkSpaceElement[tableNumberLenght, tableNumberWidth];
			CreateRoom(room,transponeServiceWidth,transponeServiceHeight, tableNumberLenght,tableNumberWidth, canvas);
		}

		private void CreateRoom(RoomEntity roomEntity, TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
				Stroke = Brushes.Black,
			};

			for (int i = 0; i < tableNumberWidth; i++)
			{
				for (int j = 0; j < tableNumberHeight; j++)
				{
					new WorkSpaceElement(transponeServiceWidth, transponeServiceHeight, canvas,
						 i * (transponeServiceWidth.ConditionalUnit * LengthConverter.SantimettersToMetters(Limitations.MINIMUM_TABLE_WIDTH) + transponeServiceWidth.ConditionalUnit * Limitations.BETWEEN_TABLES), // SetLeft
						 j * transponeServiceHeight.ConditionalUnit * (Limitations.MINIMAL_WIDTH)); // SetTop
				}
			}
			canvas.Children.Add(RoomRectangle);
			
		}
	}
}
