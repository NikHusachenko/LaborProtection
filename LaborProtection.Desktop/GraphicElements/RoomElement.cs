using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.TransponeServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace LaborProtection.Desktop.GraphicElements
{
	public class RoomElement
	{
		public WorkSpaceElement[,] tables { get; set; }
		public Rectangle RoomRectangle { get; set; }
		public RoomElement(RoomEntity room,WorkSpaceEntity workSpace,TransponeService transponeServiceWidth,TransponeService transponeServiceHeight,int tableNumberLenght,int tableNumberWidth,Canvas canvas)//int roomWidth, int roomHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			tables = new WorkSpaceElement[tableNumberLenght, tableNumberWidth];
			CreateRoom(room,workSpace,transponeServiceWidth,transponeServiceHeight, tableNumberLenght,tableNumberWidth, canvas);
		}

		private void CreateRoom(RoomEntity roomEntity,WorkSpaceEntity workSpace,TransponeService transponeServiceWidth, TransponeService transponeServiceHeight, int tableNumberWidth, int tableNumberHeight, Canvas canvas)
		{
			RoomRectangle = new Rectangle
			{
				Width = transponeServiceWidth.ConditionalUnit * roomEntity.Width,
				Height = transponeServiceHeight.ConditionalUnit * roomEntity.Length,
				Stroke = Brushes.Black,
			};

			for (int i = 0; i < tableNumberWidth; i++)
			{
				for (int j = 0; j < tableNumberHeight; j++)
				{
					new WorkSpaceElement(workSpace,transponeServiceWidth, transponeServiceHeight, canvas,
						 i * transponeServiceWidth.ConditionalUnit * workSpace.Width, // SetLeft
						 j * transponeServiceHeight.ConditionalUnit * workSpace.Length); // SetTop
				}
			}
			canvas.Children.Add(RoomRectangle);
			
		}
	}
}
