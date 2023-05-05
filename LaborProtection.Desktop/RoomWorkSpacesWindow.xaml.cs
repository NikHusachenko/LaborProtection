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
		private readonly TransponeService _transponeService;
		private static int _tablesInWidth;
		private static int _tablesInLenght;
		public RoomWorkSpacesWindow(RoomEntity room,int tablesInWidth,int tablesInLength)
		{
			_roomEntity = room;
			_spaces = _roomEntity.WorkSpaces;
			_transponeService = new TransponeService(1, 1);
			_tablesInWidth= tablesInWidth;
			_tablesInLenght= tablesInLength;
			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			RoomElement roomElement = new RoomElement(_roomEntity,_tablesInWidth,_tablesInLenght,canvasGrid);
		}
	}
}
