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
		private static TransponeService _transponseServiceLength;
		private static TransponeService _transponseSerivceWidth;
		private static int _tablesInLength;
		private static int _tablesInWidth;
		public RoomWorkSpacesWindow(RoomEntity room, int workSpacesLenght,int workSpacesWidth)
		{
			_roomEntity = room;
			_tablesInLength = workSpacesLenght;
			_tablesInWidth = workSpacesWidth;
			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			_transponseServiceLength = new TransponeService(_roomEntity.Length, canvasGrid.ActualWidth);
			_transponseSerivceWidth = new TransponeService(_roomEntity.Width, canvasGrid.ActualHeight);
			RoomElement roomElement = new RoomElement(_roomEntity, _transponseServiceLength, _transponseSerivceWidth, _tablesInLength,_tablesInWidth,canvasGrid);
		}
	}
}
