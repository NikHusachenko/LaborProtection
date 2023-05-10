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
		public LampElement(double lampSpaceLenght, double lampSpaceWidth, TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			CreateElement(lampSpaceLenght, lampSpaceWidth, transponeServiceWidth, transponeServiceLength, roomCanvas, SetLeft, SetTop);
		}
		private void CreateElement(double lampSpaceLenght, double lampSpaceWidth,
		TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			Canvas LampSpaceCanvas = new Canvas()
			{
				Width = lampSpaceLenght,
				Height = lampSpaceWidth,
				
			};
			Canvas.SetLeft(LampSpaceCanvas, SetLeft);
			Canvas.SetTop(LampSpaceCanvas, SetTop);

			LampRectangleElement = new Rectangle()
			{
				Width = lampSpaceLenght/3,
				Height = lampSpaceWidth/3,
				Stroke = Brushes.Black,
				Fill = Brushes.White
			};
			LampSpaceCanvas.Children.Add(LampRectangleElement);
			roomCanvas.Children.Add(LampSpaceCanvas);
		}
	}
}
