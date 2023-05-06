namespace LaborProtection.Services.TransponeServices
{
	public class TransponeService
	{

		public double ConditionalUnit { get; }//Pixels per Meter
		/// <summary>
		/// Calculate how many pixels will be in one meter
		/// </summary>
		/// <param name="roomParameter">Side of room that fits in Canvas</param>
		/// <param name="canvasParameter" >Side of canvas which coresponds to roomParametr</param>
		public TransponeService(double roomParameter, double canvasParameter)
		{
			ConditionalUnit = canvasParameter / roomParameter;
		}
	}
}
