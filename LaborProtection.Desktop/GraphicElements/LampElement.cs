using LaborProtection.Services.TransponeServices;
using System.Drawing;
using System.Windows.Controls;

namespace LaborProtection.Desktop.GraphicElements
{
	class LampElement
	{
		public Rectangle LampRectangle { get; set; }
		public Rectangle LampSpace { get; set; }
		private static TransponeService TransponeServiceWidth { get; set; }
		private static TransponeService TransponeServiceHeight { get; set; }

		public LampElement(TransponeService transponeServiceWidth, TransponeService transponeServiceLength, Canvas roomCanvas, double SetLeft, double SetTop)
		{
			TransponeServiceWidth = transponeServiceWidth;
			TransponeServiceHeight = transponeServiceLength;

		}
		private void CreateElement()
		{

		}
	}
}
