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

		public LampElement(TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			TransponeServiceWidth = transponeServiceWidth;
			TransponeServiceHeight = transponeServiceLength;
			CreateElement(transponeServiceWidth, transponeServiceLength, roomCanvas, SetLeft, SetTop);
		}
		private void CreateElement(//double lampLenght,double lampWidth,double lampSpaceLenght,double lampSpaceHeight,
		TransponeService transponeServiceWidth, TransponeService transponeServiceLength,Canvas roomCanvas, double SetLeft,double SetTop)
		{
			Canvas LampSpaceCanvas = new Canvas()
			{
				Width = TransponeServiceWidth.ConditionalUnit * 1.5,
				Height = TransponeServiceHeight.ConditionalUnit * 3,
				//Background = Brushes.Black
			};

			Canvas.SetLeft(LampSpaceCanvas, SetLeft);
			Canvas.SetTop(LampSpaceCanvas,SetTop);

			LampRectangleElement = new Rectangle()
			{
				Width = TransponeServiceWidth.ConditionalUnit * 0.5,
				Height = TransponeServiceHeight.ConditionalUnit * 1.5,
			    Stroke = Brushes.Black,
				Fill = Brushes.White
			};
			Canvas.SetLeft(LampRectangleElement, LampSpaceCanvas.Width / 2 - LampRectangleElement.Width / 2);
			Canvas.SetTop(LampRectangleElement, LampSpaceCanvas.Height/2 - LampRectangleElement.Height / 2);
			LampSpaceElement = new Rectangle()
			{
				Width = TransponeServiceWidth.ConditionalUnit * Limitations.DEFAULT_LAMP_SPACE_WIDTH,
				Height = TransponeServiceHeight.ConditionalUnit * Limitations.DEFAULT_LAMP_SPACE_HEIGHT,
				//Stroke = Brushes.Black,
				Fill = Brushes.Wheat,
			};
			LampSpaceCanvas.Children.Add(LampSpaceElement);
			LampSpaceCanvas.Children.Add(LampRectangleElement);
			roomCanvas.Children.Add(LampSpaceCanvas);
		}
	}
}
