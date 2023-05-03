using LaborProtection.Calculation.Constants;
using LaborProtection.Services.TransponeServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class RoomElement
	{
		public WorkSpaceElement[,] tables { get; set; }
		public Rectangle RoomRectangle { get; set; }
		private TransponeService TransponeServiceWidth { get; set; }
		private TransponeService TransponeServiceHeight { get; set; }

		public RoomElement(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			TransponeServiceWidth = new TransponeService(roomWidth, canvas.ActualWidth);
			TransponeServiceHeight = new TransponeService(roomHeight, canvas.ActualHeight);

			tables = new WorkSpaceElement[tableNumberWidth, tableNumberHeight];
			CreateRoom(roomWidth, roomHeight, tableNumberWidth, tableNumberHeight, canvas);
		}

		private void CreateRoom(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = TransponeServiceWidth.ConditionalUnit * roomWidth,
				Height = TransponeServiceHeight.ConditionalUnit * roomHeight,
				Stroke = Brushes.Black,
			};

			for (int i = 0; i < tableNumberWidth; i++)
			{
				for (int j = 0; j < tableNumberHeight; j++)
				{
					new WorkSpaceElement(TransponeServiceWidth, TransponeServiceHeight, canvas,
						() => i * TransponeServiceWidth.ConditionalUnit * (Limitations.BETWEEN_TABLES), // SetLeft
						() => j * TransponeServiceHeight.ConditionalUnit * (Limitations.BETWEEB_MONITORS)); // SetTop
				}
			}
			canvas.Children.Add(RoomRectangle);
			
		}
	}
}
