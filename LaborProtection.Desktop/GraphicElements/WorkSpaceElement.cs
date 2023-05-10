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
		public WorkSpaceElement(WorkSpaceEntity workSpace, TransponeService transponeServiceLength, TransponeService transponeServiceWidth, Canvas roomCanvas,double scaleLength,double scaleWidth ,double SetLeft, double SetTop)
		{
			CreateTable(transponeServiceLength,transponeServiceWidth,scaleLength,scaleWidth,workSpace, roomCanvas, SetLeft, SetTop);
		}
		public void CreateTable(TransponeService transponeServiceLength, TransponeService transponeServiceWidth, double scaleLength, double scaleWidth, WorkSpaceEntity workSpace, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			Canvas WorkSpaceCanvas = new Canvas()
			{
				Width = transponeServiceLength.ConditionalUnit * workSpace.Length * scaleLength,
				Height = transponeServiceWidth.ConditionalUnit * workSpace.Width * scaleWidth,
				Background = Brushes.Black
			};

			Canvas.SetLeft(WorkSpaceCanvas, SetLeft);
			Canvas.SetTop(WorkSpaceCanvas, SetTop);

			MonitorElement = new Rectangle()
			{
				Width = transponeServiceLength.ConditionalUnit * 0.2 * scaleLength,
				Height = transponeServiceWidth.ConditionalUnit * 0.1 * scaleWidth,
				Stroke = Brushes.Black,
				Fill = Brushes.White,

			};

			Canvas.SetLeft(MonitorElement, WorkSpaceCanvas.Width / 2 - MonitorElement.Width / 2);
			TableElement = new Rectangle()
			{
				Width = transponeServiceLength.ConditionalUnit * workSpace.Table.Length * scaleLength,
				Height = transponeServiceWidth.ConditionalUnit * workSpace.Table.Width * scaleWidth,
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};
			Canvas.SetLeft(TableElement, WorkSpaceCanvas.Width / 2 - TableElement.Width / 2);
			WorkAreaElement = new Rectangle()
			{
				Width = transponeServiceLength.ConditionalUnit * workSpace.Length * scaleLength,
				Height = transponeServiceWidth.ConditionalUnit * workSpace.Width * scaleWidth,
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