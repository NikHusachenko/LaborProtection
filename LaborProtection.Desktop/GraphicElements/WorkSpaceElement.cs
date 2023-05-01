using LaborProtection.Calculation.Constants;
using LaborProtection.Desktop.GraphicElements.Converter;
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
				Height = LenghtConverter.GetConditionalUnit(250,roomCanvas.Height),
				Width = LenghtConverter.GetConditionalUnit(Limitations.MINIMUM_TABLE_WIDTH,roomCanvas.Width),
			};
			Canvas.SetLeft(WorkSpaceCanvas, SetLeft());
			Canvas.SetTop(WorkSpaceCanvas, SetTop());

			MonitorElement = new Rectangle()
			{
				Height = LenghtConverter.GetConditionalUnit(16,WorkSpaceCanvas.Height),
				Width = LenghtConverter.GetConditionalUnit(35,WorkSpaceCanvas.Width),
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};


			TableElement = new Rectangle()
			{
				Height = LenghtConverter.GetConditionalUnit(Limitations.MINIMUM_TABLE_LENGTH, WorkSpaceCanvas.Height),
				Width = LenghtConverter.GetConditionalUnit(Limitations.MINIMUM_TABLE_WIDTH, WorkSpaceCanvas.Height),
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};

			WorkAreaElement = new Rectangle()
			{
				Height = LenghtConverter.GetConditionalUnit(Limitations.BETWEEB_MONITORS, WorkSpaceCanvas.Height),
				Width = LenghtConverter.GetConditionalUnit(Limitations.MINIMUM_TABLE_WIDTH, WorkSpaceCanvas.Height),
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
