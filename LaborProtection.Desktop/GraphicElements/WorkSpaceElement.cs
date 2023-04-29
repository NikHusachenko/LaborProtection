using LaborProtection.Calculation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public static void CreateTable(Canvas roomCanvas, Func<double> SetLeft, Func<double> SetTop)
		{
			Canvas WorkSpaceCanvas = new Canvas()
			{
				Height = 250,
				Width = Limitations.MINIMUM_TABLE_WIDTH,
			};
			Canvas.SetLeft(WorkSpaceCanvas, SetLeft());
			Canvas.SetTop(WorkSpaceCanvas, SetTop());

			MonitorElement = new Rectangle()
			{
				Height = 16,
				Width = 35,
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};


			TableElement = new Rectangle()
			{
				Height = Limitations.MINIMUM_TABLE_LENGTH,
				Width = Limitations.MINIMUM_TABLE_WIDTH,
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};

			WorkAreaElement = new Rectangle()
			{
				Height = Limitations.BETWEEB_MONITORS,
				Width = Limitations.MINIMUM_TABLE_WIDTH,
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
