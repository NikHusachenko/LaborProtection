using LaborProtection.Calculation.Constants;
using LaborProtection.Calculation.Entities;
using LaborProtection.Services.WorkSpaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static LaborProtection.Calculation.Constants.LightReflection;

namespace LaborProtection.Desktop.Pages.Calculations
{
    public partial class CalculationAreaPage : Page
    {
        private readonly IWorkSpaceService _workSpaceService;

        public CalculationAreaPage(IWorkSpaceService workSpaceService)
        {
            _workSpaceService = workSpaceService;

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

        private void roomHeightTextBox_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
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

        private void lampSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bulbSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void viewDrawingButton_Click(object sender, RoutedEventArgs e)
        {
            CalculationWorkArea();

            RoomWorkSpacesWindow roomWorkSpacesWindow = new RoomWorkSpacesWindow(new RoomEntity()
            {
                Height = 3,
                Length = 5,
                Width = 7,
                WorkSpaces = new List<WorkSpaceEntity>
                {
                    new WorkSpaceEntity()
                    {
                        Length = 3.2,
                        Width = 2.5,
                        Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
                    },
					new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},
new WorkSpaceEntity()
					{
						Length = 3.2,
						Width = 2.5,
						Height = Limitations.MINIMAL_VOLUME / (3.2 * 2.5),
					},

				}
			});
            roomWorkSpacesWindow.ShowDialog();
        }

        private async void CalculationWorkArea()
        {
            ClearAllError();

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

            var spaceArea = await _workSpaceService.GetWorkSpace(roomLength, roomWidth, roomHeight, tableLengthSlider.Value, tableWidthSlider.Value);
            if (spaceArea.IsError)
            {
                roomLengthLabel.Foreground = Brushes.Red;
                roomWidthLabel.Foreground = Brushes.Red;
                tableLengthLabel.Foreground = Brushes.Red;
                tableWidthLabel.Foreground = Brushes.Red;
                workAreaLabel.Foreground = Brushes.Red;
                return;
            }
            workAreaValueLabel.Content = spaceArea.Value.Width * spaceArea.Value.Length;
            workVolumeValueLabel.Content = spaceArea.Value.Width * spaceArea.Value.Length * spaceArea.Value.Height;
            workLengthValueLabel.Content = spaceArea.Value.Length;
            workWidthValueLabel.Content = spaceArea.Value.Width;

            int inLength = _workSpaceService.GetWorkSpacesInLegth(spaceArea.Value.Length, roomLength);
            tablesInLengthValueLabel.Content = inLength;
            int inWidth = _workSpaceService.GetWorkSpacesInWidth(spaceArea.Value.Width, roomWidth);
            tablesInWidthValueLabel.Content = inWidth;

            /*var spaceVolume = await _workSpaceService.GetWorkSpaceVolume(roomLength, roomWidth, roomHeight, tableLengthSlider.Value, tableWidthSlider.Value);
            if (spaceVolume.IsError)
            {
                roomLengthLabel.Foreground = Brushes.Red;
                roomWidthLabel.Foreground = Brushes.Red;
                roomHeightLabel.Foreground = Brushes.Red;
                tableLengthLabel.Foreground = Brushes.Red;
                tableWidthLabel.Foreground = Brushes.Red;
                workVolumeLabel.Foreground = Brushes.Red;
            }
            workVolumeValueLabel.Content = spaceVolume.Value;

            var tablesInLengthResponse = await _workSpaceService.GetSpacesInLength(roomLength, tableLengthSlider.Value);
            if (tablesInLengthResponse.IsError)
            {
                roomLengthLabel.Foreground = Brushes.Red;
                tableLengthLabel.Foreground = Brushes.Red;
                tablesInWidthLabel.Foreground = Brushes.Red;
                tablesInLengthLabel.Foreground = Brushes.Red;
                totalTablesCountLabel.Foreground = Brushes.Red;
                return;
            }
            tablesInLengthValueLabel.Content = tablesInLengthResponse.Value;

            var tablesInWidthResponse = await _workSpaceService.GetSpacesInWidth(roomWidth, tableWidthSlider.Value);
            if (tablesInWidthResponse.IsError)
            {
                roomWidthLabel.Foreground = Brushes.Red;
                tableWidthLabel.Foreground = Brushes.Red;
                tablesInWidthLabel.Foreground = Brushes.Red;
                tablesInLengthLabel.Foreground = Brushes.Red;
                totalTablesCountLabel.Foreground = Brushes.Red;
                return;
            }
            tablesInWidthValueLabel.Content = tablesInWidthResponse.Value;
            totalTablesCountValueLabel.Content = tablesInLengthResponse.Value * tablesInWidthResponse.Value;*/
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