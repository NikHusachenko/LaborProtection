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
		private static TransponeService _transponeServiceWidth;
		private static TransponeService _transponseSerivceHeight;
		private readonly RoomEntity _roomEntity;
		private readonly ILightService _lightService;
		private readonly LampEntity _lampEntity;
		private readonly BulbEntity _bulbEntity;
		private readonly double _floorReflection;
		private readonly double _ceillingReflection;
		private readonly double _wallReflection;
		private readonly LampType _lampType;
		private static ResponseService<int> lampsNumber;

		public RoomLampsWindow(RoomEntity room, ILightService lightService, LampEntity lampEntity, BulbEntity bulbEntity,
			double floorReflection, double wallReflection, double ceillingReflection, LampType lampType)
		{
			_roomEntity = room;
			_lightService = lightService;
			_bulbEntity = bulbEntity;
			_lampEntity = lampEntity;
			_floorReflection = floorReflection;
			_ceillingReflection = ceillingReflection;
			_wallReflection = wallReflection;
			_lampType = lampType;

			InitializeComponent();
		}
		private async void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			lampsNumber = await _lightService.GetLampCount(_roomEntity, _lampEntity, _bulbEntity, _floorReflection, _wallReflection, _ceillingReflection, _lampType);
			canvasGrid.Visibility = Visibility.Visible;
			_transponeServiceWidth = new TransponeService(_roomEntity.Width, canvasGrid.ActualWidth);
			_transponseSerivceHeight = new TransponeService(_roomEntity.Length, canvasGrid.ActualHeight);

			RoomElement roomElement = new RoomElement(_roomEntity, _transponeServiceWidth, _transponseSerivceHeight, lampsNumber.Value, canvasGrid);
		}
	}
}
