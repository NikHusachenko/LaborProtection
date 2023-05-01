using LaborProtection.Calculation.Constants;
using LaborProtection.Desktop.GraphicElements.Converter;
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

		public RoomElement(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			tables = new WorkSpaceElement[tableNumberWidth, tableNumberHeight];
			CreateRoom(roomWidth, roomHeight, tableNumberWidth, tableNumberHeight, canvas);
		}

		private void CreateRoom(int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			Canvas roomCanvas = new Canvas()
			{
				Width = LenghtConverter.GetConditionalUnit(roomWidth, canvas.Width),
				Height = LenghtConverter.GetConditionalUnit(roomHeight, canvas.Height)
				//HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
			};
			Canvas.SetLeft(roomCanvas, (canvas.Width - roomWidth) / 2);
			Canvas.SetTop(roomCanvas, (canvas.Height - roomHeight) / 2);
			RoomRectangle = new Rectangle
			{
				Width = LenghtConverter.GetConditionalUnit(roomWidth, canvas.Height),
				Height = LenghtConverter.GetConditionalUnit(roomHeight, canvas.Height),
				Stroke = Brushes.Black,
			};
			StackPanel tablesPanel = new StackPanel();

			for (int i = 0; i < tableNumberWidth; i++)
			{
				for (int j = 0; j < tableNumberHeight; j++)
				{
					WorkSpaceElement.CreateTable(roomCanvas, () => i * LenghtConverter.GetConditionalUnit((Limitations.BETWEEN_TABLES * 100), canvas.Width), () => j * LenghtConverter.GetConditionalUnit((Limitations.BETWEEB_MONITORS * 100), canvas.Height));
				}
			}
			roomCanvas.Children.Add(RoomRectangle);
			canvas.Children.Clear();
			canvas.Children.Add(roomCanvas);
		}

	}
}
