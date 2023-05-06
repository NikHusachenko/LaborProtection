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

		private static int _lampsInWidth;
		private static int _lampsInHeight;
		public RoomLampsWindow(RoomEntity room)//, ILightService lightService, LampEntity lampEntity, BulbEntity bulbEntity,
			//double floorReflection,double wallReflection, double ceillingReflection,LampType lampType)
		{
			_roomEntity = room;
			//_lightService = lightService;

			//MessageBox.Show(lampsNumber.ToString());
			//lampsNumber = _lightService.GetLampCount(room,lampEntity,bulbEntity,floorReflection,wallReflection,ceillingReflection,lampType);

			
			//int lampsNumber = _lightService.GetLampCount(room, lampEntity, bulbEntity, floorReflection, wallReflection, ceillingReflection, lampEntity.Type);
			//_lampsInHeight = Services.WorkSpaceServices.Helpers.LengthConverter.NumbersOfElements(room.Length, room);
			//_lampsInWidth = Services.WorkSpaceServices.Helpers.LengthConverter.NumbersOfElements(room.Width, room.WorkSpace.Width);

			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;
			_transponeServiceWidth = new TransponeService(_roomEntity.Width, canvasGrid.ActualWidth);
			_transponseSerivceHeight = new TransponeService(_roomEntity.Length, canvasGrid.ActualHeight);

			RoomElement<LampElement> roomElement = new RoomElement<LampElement>(_roomEntity, _transponeServiceWidth, _transponseSerivceHeight, 6,3, canvasGrid);
		}
	}
}
