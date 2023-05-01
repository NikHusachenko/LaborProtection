using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtection.Desktop.GraphicElements.Converter
{
	public static class LenghtConverter
	{
		public static double GetConditionalUnit(double pixels, double roomValue)
		{
			return roomValue / pixels;
		}
	}
}
