using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Database.Entities;
using LaborProtection.Desktop.Windows.Views;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.WorkSpaceServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static LaborProtection.Calculation.Constants.LightReflection;

namespace LaborProtection.Desktop.Pages.Calculations
{
	public partial class CalculationAreaPage : Page
	{
		private readonly IWorkSpaceService _workSpaceService;
		private readonly ILampService _lampService;
		private readonly IBulbService _bulbService;
		private readonly SemaphoreSlim _semaphoreSlim;

		private LampEntity _selectedLamp;
		private BulbEntity _selectedBulb;

		private ViewLampInformationWindow _viewLampWindow;
		private ViewBulbInformationWindow _viewBulbWindow;

		private static int tablesInLength;
		private static int tablesInWidth;
		public CalculationAreaPage(IWorkSpaceService workSpaceService,
			ILampService lampService,
			IBulbService bulbService)
		{
			_workSpaceService = workSpaceService;
			_lampService = lampService;
			_bulbService = bulbService;
			_semaphoreSlim = new SemaphoreSlim(1);

			InitializeComponent();

			var floorReflections = Enum.GetValuesAsUnderlyingType(typeof(FloorReflection));
			foreach (var item in floorReflections)
			{
				floorReflectionComboBox.Items.Add(item);
			}

			var wallReflections = Enum.GetValuesAsUnderlyingType(typeof(WallReflection));
			foreach (var item in wallReflections)
			{
				wallReflectionComboBox.Items.Add(item);
			}

			var cellingReflections = Enum.GetValuesAsUnderlyingType(typeof(CellingReflection));
			foreach (var item in cellingReflections)
			{
				cellingReflectionComboBox.Items.Add(item);
			}
		}

		private void roomWidthTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			CalculationWorkArea();
		}

		private void roomLengthTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			CalculationWorkArea();
		}

		private void roomHeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			CalculationWorkArea();
		}

		private void floorReflectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void wallReflectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ceillingReflectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void tableWidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (tableWidthSliderValueLabel != null)
			{
				tableWidthSliderValueLabel.Content = (int)tableWidthSlider.Value;
			}
		}

		private void tableLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (tableLengthSliderValueLabel != null)
			{
				tableLengthSliderValueLabel.Content = (int)tableLengthSlider.Value;
			}
		}

		private async void lampSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string lampName = lampSelectorComboBox.SelectedItem as string;
			if (lampName != null)
			{
				var response = await _lampService.GetByName(lampName);
				if (response.IsError)
				{
					return;
				}

				_selectedLamp = response.Value;
				lampInformationButton.IsEnabled = true;

				BitmapImage bitmap = new BitmapImage(new Uri(Path.GetFullPath(_selectedLamp.ImagePath)));
				selectedLampImage.Source = bitmap;
			}
			else
			{
				lampInformationButton.IsEnabled = false;
			}
		}

		private async void bulbSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string bulbName = bulbSelectorComboBox.SelectedItem as string;
			if (bulbName != null)
			{
				var response = await _bulbService.GetByName(bulbName);
				if (response.IsError)
				{
					return;
				}

				_selectedBulb = response.Value;
				bulbInformationButton.IsEnabled = true;
			}
			else
			{
				bulbInformationButton.IsEnabled = false;
			}
		}

		private void viewDrawingButton_Click(object sender, RoutedEventArgs e)
		{
			CalculationWorkArea();

			TableEntity tableEntity = new TableEntity()
			{
				Length = Services.WorkSpaceServices.Helpers.LengthConverter.SantimettersToMetters(tableWidthSlider.Value),
				Width = Services.WorkSpaceServices.Helpers.LengthConverter.SantimettersToMetters(tableLengthSlider.Value),
			};
			WorkSpaceEntity workSpace = new WorkSpaceEntity()
			{
				Length = Limitations.BETWEEN_MONITORS,
				Width = tableEntity.Width + Limitations.BETWEEN_TABLES,
				Height = Convert.ToDouble(roomHeightTextBox.Text),
				Table = tableEntity,
			};
			RoomWorkSpacesWindow roomWorkSpacesWindow = new RoomWorkSpacesWindow(new RoomEntity()
			{
				Width = Convert.ToDouble(roomWidthTextBox.Text),
				Length = Convert.ToDouble(roomLengthTextBox.Text),
				Height = Convert.ToDouble(roomHeightTextBox.Text),
			}, workSpace);

			roomWorkSpacesWindow.ShowDialog();
		}

		private async void CalculationWorkArea()
		{
			ClearAllError();

			// Value parsing
			if (!double.TryParse(roomWidthTextBox.Text, out double roomWidth))
			{
				roomWidthLabel.Foreground = Brushes.Red;
				workVolumeLabel.Foreground = Brushes.Red;
				workAreaLabel.Foreground = Brushes.Red;
				return;
			}

			if (!double.TryParse(roomLengthTextBox.Text, out double roomLength))
			{
				roomLengthLabel.Foreground = Brushes.Red;
				workVolumeLabel.Foreground = Brushes.Red;
				workAreaLabel.Foreground = Brushes.Red;
				return;
			}

			if (!double.TryParse(roomHeightTextBox.Text, out double roomHeight))
			{
				roomHeightLabel.Foreground = Brushes.Red;
				workVolumeLabel.Foreground = Brushes.Red;
				workAreaLabel.Foreground = Brushes.Red;
				return;
			}

			// Calculations
			var spaceArea = await _workSpaceService.GetWorkSpace(roomHeight, tableLengthSlider.Value, tableWidthSlider.Value);
			if (spaceArea.IsError)
			{
				roomLengthLabel.Foreground = Brushes.Red;
				roomWidthLabel.Foreground = Brushes.Red;
				tableLengthLabel.Foreground = Brushes.Red;
				tableWidthLabel.Foreground = Brushes.Red;
				workAreaLabel.Foreground = Brushes.Red;
				return;
			}

			var workSpaceResult = await _workSpaceService.GetWorkSpace(roomHeight, tableLengthSlider.Value, tableWidthSlider.Value);
			if (workSpaceResult.IsError)
			{
				roomHeightLabel.Foreground = Brushes.Red;
				tableLengthLabel.Foreground = Brushes.Red;
				tableWidthLabel.Foreground = Brushes.Red;
				return;
			}

			var getRoomResult = _workSpaceService.GetRoom(roomLength, roomWidth, roomHeight, workSpaceResult.Value);
			if (getRoomResult.IsError)
			{
				roomHeightLabel.Foreground = Brushes.Red;
				tableLengthLabel.Foreground = Brushes.Red;
				tableWidthLabel.Foreground = Brushes.Red;
				workAreaLabel.Foreground = Brushes.Red;
				workVolumeLabel.Foreground = Brushes.Red;
				return;
			}

			workAreaValueLabel.Content = spaceArea.Value.Width * spaceArea.Value.Length;
			workVolumeValueLabel.Content = spaceArea.Value.Width * spaceArea.Value.Length * spaceArea.Value.Height;
			workLengthValueLabel.Content = spaceArea.Value.Length;
			workWidthValueLabel.Content = spaceArea.Value.Width;

			int inLength = _workSpaceService.GetWorkSpacesInLegth(spaceArea.Value.Length, roomLength);
			tablesInLengthValueLabel.Content = inLength;
			tablesInLength = inLength;
			int inWidth = _workSpaceService.GetWorkSpacesInWidth(spaceArea.Value.Width, roomWidth);
			tablesInWidthValueLabel.Content = inWidth;
			tablesInWidth = inWidth;
		}

		private void ClearAllError()
		{
			ICollection<Label> labels = FindLabels(MyName);
			foreach (Label label in labels)
			{
				label.Foreground = Brushes.Black;
			}
		}

		private ICollection<Label> FindLabels(DependencyObject obj)
		{
			List<Label> labels = new List<Label>();

			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(obj, i);

				if (child is Label)
				{
					labels.Add((Label)child);
				}
				else
				{
					labels.AddRange(FindLabels(child));
				}
			}

			return labels;
		}

		private async void lampSelectorComboBox_Loaded(object sender, RoutedEventArgs e)
		{
			await _semaphoreSlim.WaitAsync();

			ICollection<LampEntity> lamps = await _lampService.GetAll();
			foreach (LampEntity lamp in lamps)
			{
				lampSelectorComboBox.Items.Add(lamp.Name);
			}

			_semaphoreSlim.Release();
		}

		private async void bulbSelectorComboBox_Loaded(object sender, RoutedEventArgs e)
		{
			await _semaphoreSlim.WaitAsync();

			ICollection<BulbEntity> bulbs = await _bulbService.GetAll();
			foreach (BulbEntity bulb in bulbs)
			{
				bulbSelectorComboBox.Items.Add(bulb.Name);
			}

			_semaphoreSlim.Release();
		}

		private async void lampInformationButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (!lampInformationButton.IsEnabled)
			{
				return;
			}

			Point mousePosition = (Window.GetWindow(this) as MainWindow).PointToScreen(Mouse.GetPosition(this));

			_viewLampWindow = new ViewLampInformationWindow(_selectedLamp);
			_viewLampWindow.Top = mousePosition.Y + 20;
			_viewLampWindow.Left = mousePosition.X + 10;
			_viewLampWindow.Show();
		}

		private void lampInformationButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			_viewLampWindow.Close();
		}

		private async void bulbInformationButton_MouseEnter(object sender, MouseEventArgs e)
		{
			if (!bulbInformationButton.IsEnabled)
			{
				return;
			}

			Point mousePosition = (Window.GetWindow(this) as MainWindow).PointToScreen(Mouse.GetPosition(this));

			_viewBulbWindow = new ViewBulbInformationWindow(_selectedBulb);
			_viewBulbWindow.Top = mousePosition.Y + 20;
			_viewBulbWindow.Left = mousePosition.X + 10;
			_viewBulbWindow.Show();
		}

		private void bulbInformationButton_MouseLeave(object sender, MouseEventArgs e)
		{
			_viewBulbWindow.Close();
		}
	}
}

// Work Are                             - 1
// Work Volume                          - 2

// Tables in width                      - 3
// Tables in length                     - 4
// Total tables count                   - 5

// Lamps in width                       - 6
// Lamps in length                      - 7
// Total lamps count                    - 8

// Bulbs in one lamp                    - 9
// Total bulbs count                    - 10

// Price on one lamp with bulbs         - 11
// Total price                          - 12