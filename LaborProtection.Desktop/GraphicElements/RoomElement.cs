using LaborProtection.Calculation.Constants;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class RoomElement
	{
		public WorkSpaceElement[,] tables { get; set; }
		public Rectangle RoomRectangle { get; set; }
		
		public RoomElement(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			tables = new WorkSpaceElement[tableNumberWidth, tableNumberHeight];
			CreateRoom(roomWidth, roomHeight, tableNumberWidth, tableNumberHeight, canvas);
		}

		private void CreateRoom(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			Canvas roomCanvas = new Canvas()
			{
				Width = roomWidth,
				Height = roomHeight,
				//HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
			};
	    	Canvas.SetLeft(roomCanvas, (canvas.Width - roomWidth) / 2);
			Canvas.SetTop(roomCanvas, (canvas.Height - roomHeight) / 2);
			RoomRectangle = new Rectangle
			{
				Width = roomWidth,
				Height = roomHeight,
				Stroke = Brushes.Black,
			};
			StackPanel tablesPanel = new StackPanel();

			for (int i = 0; i < tables.GetLength(0); i++)
			{
				for (int j = 0; j < tables.GetLength(1); j++)
				{

					WorkSpaceElement.CreateTable(roomCanvas, () => i * (Limitations.BETWEEN_TABLES * 100), () => j * (Limitations.BETWEEB_MONITORS * 100));
				}
			}

			roomCanvas.Children.Add(RoomRectangle);

			canvas.Children.Clear();
			canvas.Children.Add(roomCanvas);
		}

	}
}
