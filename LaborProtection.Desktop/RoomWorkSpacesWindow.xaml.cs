using LaborProtection.Calculation.Entities;
using LaborProtection.Desktop.GraphicElements;
using LaborProtection.Services.TransponeServices;
using System.Windows;

namespace LaborProtection.Desktop
{
	public partial class RoomWorkSpacesWindow : Window
	{
		private readonly RoomEntity _roomEntity;
		private readonly WorkSpaceEntity _space;
		private readonly TransponeService _transponeService;

		public RoomWorkSpacesWindow(RoomEntity room)
		{
			_roomEntity = room;
			_space = _roomEntity.WorkSpace;
			_transponeService = new TransponeService(1, 1);

			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			RoomElement roomElement = new RoomElement(17,5,6,1,canvasGrid);
		}
	}
}
