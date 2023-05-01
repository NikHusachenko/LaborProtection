using LaborProtection.Calculation.Constants;
using LaborProtection.Desktop.GraphicElements.Converter;
using LaborProtection.Services.TransponeServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
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
		public TransponeService TransponeService { get; set; }

		public RoomElement(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			TransponeService = new TransponeService(roomWidth, canvas.Width);

			tables = new WorkSpaceElement[tableNumberWidth, tableNumberHeight];
			CreateRoom(roomWidth, roomHeight, tableNumberWidth, tableNumberHeight, canvas);
		}

		private void CreateRoom(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			Canvas roomCanvas = new Canvas()
			{
				Width = TransponeService.ConditionalUnit * roomWidth,
				Height = TransponeService.ConditionalUnit * roomHeight
			};
			Canvas.SetLeft(roomCanvas, (canvas.Width - roomCanvas.Width) / 2);
			Canvas.SetTop(roomCanvas, (canvas.Height - roomCanvas.Height) / 2);
			RoomRectangle = new Rectangle
			{
				Width = roomCanvas.Width,
				Height = roomCanvas.Height,
				Stroke = Brushes.Black,
			};
			StackPanel tablesPanel = new StackPanel();

			for (int i = 0; i < tableNumberWidth; i++)
			{
				for (int j = 0; j < tableNumberHeight; j++)
				{
					WorkSpaceElement.CreateTable(roomCanvas,
						() => i * TransponeService.ConditionalUnit * (Limitations.BETWEEN_TABLES), // SetLeft
						() => j * TransponeService.ConditionalUnit * (Limitations.BETWEEB_MONITORS)); // SetTop
				}
			}
			roomCanvas.Children.Add(RoomRectangle);
			canvas.Children.Clear();
			canvas.Children.Add(roomCanvas);
		}
	}
}
