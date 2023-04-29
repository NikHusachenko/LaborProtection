using LaborProtection.Desktop.GraphicElements;
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
	/// Логика взаимодействия для RoomWorkSpacesWindow.xaml
	/// </summary>
	public partial class RoomWorkSpacesWindow : Window
	{
		private static double currentScale = 1;
		private readonly RoomElement room;
		public RoomWorkSpacesWindow(int Width,int Height)
		{
			InitializeComponent();
		    room = new RoomElement(Width, Height, 4, 3, CanvasGrid);

			CanvasGrid.LayoutTransform = new ScaleTransform(currentScale, currentScale);
		}

		private void DecreaseSizeButton_Click(object sender, RoutedEventArgs e)
		{
			currentScale += 0.025;
			CanvasGrid.LayoutTransform = new ScaleTransform(currentScale, currentScale);
		}

		private void IncreaseSizeButton_Click(object sender, RoutedEventArgs e)
		{
			currentScale -= 0.025;
			CanvasGrid.LayoutTransform = new ScaleTransform(currentScale, currentScale);

		}
	}
}
