using LaborProtection.Calculation.Entities;
using LaborProtection.Database.Entities;
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
		private readonly LampEntity _lampEntity;
		public RoomLampsWindow()
		{
			InitializeComponent();
		}

		private void canvasGrid_Loaded(object sender, RoutedEventArgs e)
		{
			canvasGrid.Visibility = Visibility.Visible;

		}
	}
}
