using LaborProtection.Calculation.Entities;
using LaborProtection.Desktop.GraphicElements;
using LaborProtection.Services.TransponeServices;
using System.Windows;

namespace LaborProtection.Desktop
{
	public partial class RoomWorkSpacesWindow : Window
	{
		private readonly RoomEntity _roomEntity;
		private readonly WorkSpaceEntity[,] _spaces;
		private static TransponeService _transponeServiceWidth;
		private static TransponeService _transponseSerivceHeight;
		private static int _tablesInWidth;
		private static int _tablesInHeight;
		public RoomWorkSpacesWindow(RoomEntity room,int tablesInWidth,int tablesInLength)
		{
			_roomEntity = room;
			_spaces = _roomEntity.WorkSpaces;
			
			//TransponeServiceWidth = new TransponeService(room.Width, canvas.ActualWidth);//roomWidth, canvas.ActualWidth);
			//TransponeServiceHeight = new TransponeService(room.Length, canvas.ActualHeight);// roomHeight, canvas.ActualHeight);

			_tablesInWidth = tablesInWidth;
			_tablesInHeight= tablesInLength;
			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			_transponeServiceWidth = new TransponeService(_roomEntity.Width, canvasGrid.ActualWidth);
			_transponseSerivceHeight = new TransponeService(_roomEntity.Length, canvasGrid.ActualHeight);

			RoomElement roomElement = new RoomElement(_roomEntity, _transponeServiceWidth, _transponseSerivceHeight, _tablesInWidth,_tablesInHeight,canvasGrid);
		}
	}
}
