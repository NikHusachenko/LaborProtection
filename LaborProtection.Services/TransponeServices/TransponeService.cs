using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtection.Services.TransponeServices
{
	public class TransponeService
	{
		public double ConditionalUnit { get; }//Pixels per Meter
		public TransponeService(double roomParameter,double canvasParameter)//This assumes that the canvas is wider than the room. If the canvas is taller than the room, you would use the height dimensions instead.
// roomParametr - Side of room that fits in Canvas
// canvarParametr - Side of canvas which coresponds to roomParametr
		{

			
			ConditionalUnit = canvasParameter/roomParameter;
		}
	}
}
