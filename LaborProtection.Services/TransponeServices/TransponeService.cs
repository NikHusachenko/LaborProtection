namespace LaborProtection.Services.TransponeServices
{
	public class TransponeService
	{
		public double ConditionalUnit { get; }//Pixels per Meter


		/// <summary>
		/// DESC
		/// </summary>
		/// <param name="roomParameter">Desciption for first param</param>
		/// <param name="canvasParameter">Desciption for first param</param>
		/// 

		//This assumes that the canvas is wider than the room. If the canvas is taller than the room, you would use the height dimensions instead.
		// roomParametr - Side of room that fits in Canvas
		// canvarParametr - Side of canvas which coresponds to roomParametr

		public TransponeService(double roomParameter, double canvasParameter)
		{
			ConditionalUnit = canvasParameter / roomParameter;
		}
	}
}
