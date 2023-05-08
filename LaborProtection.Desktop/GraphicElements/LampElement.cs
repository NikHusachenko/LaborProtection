using LaborProtection.Calculation.Constants;
using LaborProtection.Services.TransponeServices;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class LampElement
	{
		public static Rectangle LampRectangleElement { get; set; }
		public static Rectangle LampSpaceElement { get; set; }
		private static TransponeService TransponeServiceWidth { get; set; }
		private static TransponeService TransponeServiceHeight { get; set; }

		public LampElement(double lampSpaceLenght,double lampSpaceWidth,TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			TransponeServiceWidth = transponeServiceWidth;
			TransponeServiceHeight = transponeServiceLength;
			CreateElement(lampSpaceLenght,lampSpaceWidth,transponeServiceWidth, transponeServiceLength, roomCanvas, SetLeft, SetTop);
		}
		private void CreateElement(double lampSpaceLenght, double lampSpaceWidth,
		TransponeService transponeServiceWidth, TransponeService transponeServiceLength,Canvas roomCanvas, double SetLeft,double SetTop)
		{
			Canvas LampSpaceCanvas = new Canvas()
			{
				Width = lampSpaceLenght,
				Height = lampSpaceWidth,
				Background = Brushes.Black
			};
			Canvas.SetLeft(LampSpaceCanvas, SetLeft);
			Canvas.SetTop(LampSpaceCanvas,SetTop);

			LampRectangleElement = new Rectangle()
			{
				Width =  lampSpaceLenght,
				Height = lampSpaceWidth,
			    Stroke = Brushes.Black,
				Fill = Brushes.White
			};
			LampSpaceCanvas.Children.Add(LampRectangleElement);
			roomCanvas.Children.Add(LampSpaceCanvas);
		}
	}
}
