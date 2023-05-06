using LaborProtection.Calculation.Entities;
using LaborProtection.Services.TransponeServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class WorkSpaceElement
	{
		public static Rectangle MonitorElement { get; set; }
		public static Rectangle TableElement { get; set; }
		public static Rectangle WorkAreaElement { get; set; }
		private static TransponeService TransponeServiceWidth { get; set; }
		private static TransponeService TransponeServiceLength { get; set; }
		public WorkSpaceElement(WorkSpaceEntity workSpace, TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			TransponeServiceWidth = transponeServiceWidth;
			TransponeServiceLength = transponeServiceLength;
			CreateTable(workSpace, roomCanvas, SetLeft, SetTop);
		}
		public void CreateTable(WorkSpaceEntity workSpace, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			Canvas WorkSpaceCanvas = new Canvas()
			{
				Width = TransponeServiceWidth.ConditionalUnit * workSpace.Width,
				Height = TransponeServiceLength.ConditionalUnit * workSpace.Length,
				Background = Brushes.Black
			};

			Canvas.SetLeft(WorkSpaceCanvas, SetLeft);
			Canvas.SetTop(WorkSpaceCanvas, SetTop);

			MonitorElement = new Rectangle()
			{
				Width = TransponeServiceWidth.ConditionalUnit * 0.2,
				Height = TransponeServiceLength.ConditionalUnit * 0.1,
				Stroke = Brushes.Black,
				Fill = Brushes.White,

			};

			Canvas.SetLeft(MonitorElement, WorkSpaceCanvas.Width / 2 - MonitorElement.Width / 2);
			TableElement = new Rectangle()
			{
				Width = TransponeServiceWidth.ConditionalUnit * workSpace.Table.Width,
				Height = TransponeServiceLength.ConditionalUnit * workSpace.Table.Length,
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};
			Canvas.SetLeft(TableElement, WorkSpaceCanvas.Width / 2 - TableElement.Width / 2);
			WorkAreaElement = new Rectangle()
			{
				Width = TransponeServiceWidth.ConditionalUnit * workSpace.Width,
				Height = TransponeServiceLength.ConditionalUnit * workSpace.Length,
				Stroke = Brushes.Wheat,
				Fill = Brushes.White
			};

			WorkSpaceCanvas.Children.Add(WorkAreaElement);
			WorkSpaceCanvas.Children.Add(TableElement);
			WorkSpaceCanvas.Children.Add(MonitorElement);
			roomCanvas.Children.Add(WorkSpaceCanvas);
		}
	}
}