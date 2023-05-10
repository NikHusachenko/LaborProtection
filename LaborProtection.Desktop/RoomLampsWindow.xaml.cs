using LaborProtection.Calculation.Entities;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.Desktop.GraphicElements;
using LaborProtection.Services.LightServices;
using LaborProtection.Services.Response;
using LaborProtection.Services.TransponeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaborProtection.Desktop
{
	/// <summary>
	/// Логика взаимодействия для RoomLampsWindow.xaml
	/// </summary>
	public partial class RoomLampsWindow : Window
	{
		private static TransponeService _transponeServiceLength;
		private static TransponeService _transponseSerivceWidth;
		private readonly RoomEntity _roomEntity;
		
		private static int _lampsNumber;

		public RoomLampsWindow(RoomEntity room, int numOfElements)
		{
			_roomEntity = room;
			_lampsNumber = numOfElements;
			InitializeComponent();
		}
		private async void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			_transponeServiceLength = new TransponeService(_roomEntity.Length, canvasGrid.ActualWidth);
			_transponseSerivceWidth = new TransponeService(_roomEntity.Width, canvasGrid.ActualHeight);

			RoomElement roomElement = new RoomElement(_roomEntity, _transponeServiceLength, _transponseSerivceWidth, _lampsNumber, canvasGrid);
		}
	}
}
