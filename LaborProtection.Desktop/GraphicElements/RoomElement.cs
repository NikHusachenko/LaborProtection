using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.TransponeServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class RoomElement
	{
		public RoomEntity _roomEntity;
		public WorkSpaceElement[,] tables { get; set; }
		public Rectangle RoomRectangle { get; set; }
		private TransponeService TransponeServiceWidth { get; set; }
		private TransponeService TransponeServiceHeight { get; set; }

		public RoomElement(RoomEntity room,int tableNumberLenght,int tableNumberWidth,Canvas canvas)//int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			_roomEntity = room;
			TransponeServiceWidth = new TransponeService(room.Width,canvas.ActualWidth);//roomWidth, canvas.ActualWidth);
			TransponeServiceHeight = new TransponeService(room.Length,canvas.ActualHeight);// roomHeight, canvas.ActualHeight);
		
			tables = new WorkSpaceElement[tableNumberLenght, tableNumberWidth];
			CreateRoom(_roomEntity, tableNumberLenght,tableNumberWidth, canvas);
		}

		private void CreateRoom(RoomEntity roomEntity, int tableNumberWidth, int tableNumberLenght, Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = TransponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Height = TransponeServiceHeight.ConditionalUnit * roomEntity.Length,
				Stroke = Brushes.Black,
			};

			for (int i = 0; i < tableNumberWidth; i++)
			{
				for (int j = 0; j < tableNumberLenght; j++)
				{
					new WorkSpaceElement(TransponeServiceWidth, TransponeServiceHeight, canvas,
						() => i * TransponeServiceWidth.ConditionalUnit * (Limitations.BETWEEN_TABLES), // SetLeft
						() => j * TransponeServiceHeight.ConditionalUnit * (Limitations.MINIMAL_WIDTH)); // SetTop
				}
			}
			canvas.Children.Add(RoomRectangle);
			
		}
	}
}
