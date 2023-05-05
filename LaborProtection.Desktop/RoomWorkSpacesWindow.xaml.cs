using LaborProtection.Calculation.Entities;
using LaborProtection.Desktop.GraphicElements;
using LaborProtection.Services.TransponeServices;
using System;
using System.Windows;

namespace LaborProtection.Desktop
{
	public partial class RoomWorkSpacesWindow : Window
	{
		private readonly RoomEntity _roomEntity;
		private readonly WorkSpaceEntity _workSpaceEntity;
		private readonly WorkSpaceEntity[,] _spaces;
		private static TransponeService _transponeServiceWidth;
		private static TransponeService _transponseSerivceHeight;
		private static int _tablesInWidth;
		private static int _tablesInHeight;
		public RoomWorkSpacesWindow(RoomEntity room,WorkSpaceEntity workSpace)
		{
			_roomEntity = room;
			_workSpaceEntity = workSpace;
			_spaces = _roomEntity.WorkSpaces;
			_tablesInHeight = Services.WorkSpaceServices.Helpers.LengthConverter.NumbersOfElements(room.Length, workSpace.Length);
			_tablesInWidth = Services.WorkSpaceServices.Helpers.LengthConverter.NumbersOfElements(room.Width, workSpace.Width);
			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			_transponeServiceWidth =  new TransponeService(_roomEntity.Width, canvasGrid.ActualWidth);
			_transponseSerivceHeight = new TransponeService(_roomEntity.Length, canvasGrid.ActualHeight);

			RoomElement roomElement = new RoomElement(_roomEntity,_workSpaceEntity, _transponeServiceWidth, _transponseSerivceHeight, _tablesInWidth,_tablesInHeight,canvasGrid);
		}
	}
}
