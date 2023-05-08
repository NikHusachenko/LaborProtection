using LaborProtection.Calculation.Entities;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.Desktop.GraphicElements;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LightServices;
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
		private readonly RoomEntity _roomEntity;
		private static TransponeService _transponeServiceWidth;
		private static TransponeService _transponseSerivceHeight;
		private readonly ILightService _lightService;
		private readonly int lampsNumber;

		public RoomLampsWindow(RoomEntity room, ILightService lightService, LampEntity lampEntity, BulbEntity bulbEntity,
			double floorReflection,double wallReflection, double ceillingReflection,LampType lampType)
		{
			_roomEntity = room;
			_lightService = lightService;

			lampsNumber = _lightService.GetLampCount(room,lampEntity,bulbEntity,floorReflection,wallReflection,ceillingReflection,lampType);
			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			_transponeServiceWidth = new TransponeService(_roomEntity.Width, canvasGrid.ActualWidth);
			_transponseSerivceHeight = new TransponeService(_roomEntity.Length, canvasGrid.ActualHeight);

			RoomElement roomElement = new RoomElement(_roomEntity, _transponeServiceWidth, _transponseSerivceHeight, lampsNumber, canvasGrid);
		}
	}
}
