using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using LaborProtection.Desktop.Windows.Views;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LightServices;
using LaborProtection.Services.WorkSpaceServices;
using LaborProtection.Services.WorkSpaceServices.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly ILightService _lightService;

        private readonly SemaphoreSlim _semaphoreSlim;

        private LampEntity _selectedLamp;
        private BulbEntity _selectedBulb;

        private ViewLampInformationWindow _viewLampWindow;
        private ViewBulbInformationWindow _viewBulbWindow;

        private bool _lengthSliderIsLoaded = false;
        private bool _widthSliderIsLoaded = false;
        private bool _heightSliderIsLoaded = false;

        public CalculationAreaPage(IWorkSpaceService workSpaceService,
            ILampService lampService,
            IBulbService bulbService,
            ILightService lightService)
        {
            _workSpaceService = workSpaceService;
            _lampService = lampService;
            _bulbService = bulbService;
            _lightService = lightService;
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
            CalculationWorkArea();
        }

        private void wallReflectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculationWorkArea();
        }

        private void ceillingReflectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculationWorkArea();
        }

        private void tableWidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_widthSliderIsLoaded)
            {
                _widthSliderIsLoaded = true;
                return;
            }

            if (tableWidthSliderValueLabel != null)
            {
                tableWidthSliderValueLabel.Content = (int)tableWidthSlider.Value;
                CalculationWorkArea();
            }
        }

        private void tableLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_lengthSliderIsLoaded)
            {
                _lengthSliderIsLoaded = true;
                return;
            }

            if (tableLengthSliderValueLabel != null)
            {
                tableLengthSliderValueLabel.Content = (int)tableLengthSlider.Value;
                CalculationWorkArea();
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

                CalculationWorkArea();
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

                CalculationWorkArea();
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
                WorkSpace = workSpace,
			});
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
            var spaceArea = await _workSpaceService.GetWorkSpace(roomHeight, tableLengthSlider.Value, tableWidthSlider.Value, tableHeightSlider.Value);
            if (spaceArea.IsError)
            {
                roomLengthLabel.Foreground = Brushes.Red;
                roomWidthLabel.Foreground = Brushes.Red;
                tableLengthLabel.Foreground = Brushes.Red;
                tableWidthLabel.Foreground = Brushes.Red;
                workAreaLabel.Foreground = Brushes.Red;
                return;
            }

            var getRoomResult = _workSpaceService.GetRoom(roomLength, roomWidth, roomHeight, spaceArea.Value);
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
            int inWidth = _workSpaceService.GetWorkSpacesInWidth(spaceArea.Value.Width, roomWidth);
            tablesInLengthValueLabel.Content = inLength;
            tablesInWidthValueLabel.Content = inWidth;
            totalTablesCountValueLabel.Content = inLength * inWidth;


            // Light calculations
            if (floorReflectionComboBox.SelectedValue == null)
            {
                floorReflectionLabel.Foreground = Brushes.Red;
                return;
            }
            string floorReflectionValue = floorReflectionComboBox.SelectedValue.ToString();
            if (!int.TryParse(floorReflectionValue, out int floorReflection))
            {
                floorReflectionLabel.Foreground = Brushes.Red;
                return;
            }

            if (wallReflectionComboBox.SelectedValue == null)
            {
                wallReflectionLabel.Foreground = Brushes.Red;
                return;
            }
            string wallReflectionValue = wallReflectionComboBox.SelectedValue.ToString();
            if (!int.TryParse(wallReflectionValue, out int wallReflection))
            {
                wallReflectionLabel.Foreground = Brushes.Red;
                return;
            }

            if (cellingReflectionComboBox.SelectedValue == null)
            {
                ceillingReflectionLabel.Foreground = Brushes.Red;
                return;
            }
            string ceillingReflectionValue = cellingReflectionComboBox.SelectedValue.ToString();
            if (!int.TryParse(ceillingReflectionValue, out int ceillingreflection))
            {
                ceillingReflectionLabel.Foreground = Brushes.Red;
                return;
            }

            if (_selectedLamp == null)
            {
                lampTypeLabel.Foreground = Brushes.Red;
                return;
            }

            if (_selectedBulb == null)
            {
                lampBulbLabel.Foreground = Brushes.Red;
                return;
            }

            var lampResponse = await _lightService.GetLampCount(getRoomResult.Value, _selectedLamp, _selectedBulb, floorReflection, wallReflection, ceillingreflection, _selectedLamp.Type);
            if (lampResponse.IsError)
            {
                floorReflectionLabel.Foreground = Brushes.Red;
                wallReflectionLabel.Foreground = Brushes.Red;
                ceillingReflectionLabel.Foreground = Brushes.Red;
                return;
            }

            int lamps = lampResponse.Value;

            totalLampsCountValueLabel.Content = lamps;
            bulbsInLampValueLabel.Content = _selectedLamp.BulbCount;
            totalBulbsCountValueLabel.Content = lamps * _selectedLamp.BulbCount;
            bulbsInLampCostValueLabel.Content = _selectedLamp.BulbCount * _selectedBulb.Price + _selectedLamp.Price;
            totalPriceValueLabel.Content = lamps * _selectedLamp.Price + lamps * _selectedLamp.BulbCount * _selectedBulb.Price;
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

            lampSelectorComboBox.Items.Clear();
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

            bulbSelectorComboBox.Items.Clear();
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

        private void tableHeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_heightSliderIsLoaded)
            {
                _heightSliderIsLoaded = true;
                return;
            }

            if (tableHeightSliderValueLabel != null)
            {
                tableHeightSliderValueLabel.Content = (int)tableHeightSlider.Value;
                CalculationWorkArea();
            }
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