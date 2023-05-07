using LaborProtection.Services.TransponeServices;
using System.Windows.Controls;
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

		public LampElement(double lampSpaceLenght, double lampSpaceWidth, TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			TransponeServiceWidth = transponeServiceWidth;
			TransponeServiceHeight = transponeServiceLength;
			CreateElement(lampSpaceLenght, lampSpaceWidth, transponeServiceWidth, transponeServiceLength, roomCanvas, SetLeft, SetTop);
		}
		private void CreateElement(double lampLenght, double lampWidth,
		TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			Canvas LampSpaceCanvas = new Canvas()
			{
				Width = TransponeServiceWidth.ConditionalUnit * lampLenght,
				Height = TransponeServiceHeight.ConditionalUnit * lampWidth,
				Background = Brushes.Black
			};
			Canvas.SetLeft(LampSpaceCanvas, SetLeft);
			Canvas.SetTop(LampSpaceCanvas, SetTop);

			LampRectangleElement = new Rectangle()
			{
				Width = TransponeServiceWidth.ConditionalUnit * lampLenght,
				Height = TransponeServiceHeight.ConditionalUnit * lampWidth,
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};
			//Canvas.SetLeft(LampRectangleElement, LampSpaceCanvas.Width / 2 - LampRectangleElement.Width / 2);
			//Canvas.SetTop(LampRectangleElement, LampSpaceCanvas.Height/2 - LampRectangleElement.Height / 2);
			//LampSpaceElement = new Rectangle()
			//{
			//	Width = TransponeServiceWidth.ConditionalUnit * lampLenght,
			//	Height = TransponeServiceHeight.ConditionalUnit * lampWidth,
			//	//Stroke = Brushes.Black,
			//	Fill = Brushes.Wheat,
			//};
			//LampSpaceCanvas.Children.Add(LampSpaceElement);
			LampSpaceCanvas.Children.Add(LampRectangleElement);
			roomCanvas.Children.Add(LampSpaceCanvas);
		}
	}
}
