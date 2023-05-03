using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Services.LampServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LaborProtection.Desktop.Pages
{
    public partial class ViewLampPage : Page
    {
        private readonly ILampService _lampService;

        public ViewLampPage(ILampService lampService)
        {
            _lampService = lampService;

            InitializeComponent();
        }

        private async void lampViewPanel_Loaded(object sender, RoutedEventArgs e)
        {
            lampViewPanel.Children.Clear();

            ICollection<LampEntity> lamps = await _lampService.GetAll();
            foreach (LampEntity lamp in lamps)
            {
                StackPanel lampPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Width = lampViewContainer.ActualWidth,
                    Height = 200,
                    Margin = new Thickness(0, 0, 0, 10),
                    Name = $"panel_{lamp.Id}",
                };

                Border informationBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 9 * 4,
                    Height = 200,
                    Padding = new Thickness(10),
                    BorderBrush = Brushes.Gray,
                    CornerRadius = new CornerRadius(25, 0, 0, 25),
                    BorderThickness = new Thickness(1),
                };

                string lampInformation = $"{lamp.Id}\n{lamp.Name}\n{lamp.Type}\n{lamp.BulbCount}\n{lamp.Price}";
                TextBlock textBlock = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Text = lampInformation,
                    FontSize = 22,
                };
                informationBorder.Child = textBlock;
                lampPanel.Children.Add(informationBorder);

                Border imageBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 9 * 4,
                    Height = 200,
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    BorderBrush = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                };

                if (File.Exists(lamp.ImagePath))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(Path.GetFullPath(lamp.ImagePath)));
                    Image image = new Image()
                    {
                        Source = bitmap,
                    };
                    imageBorder.Child = image;
                    lampPanel.Children.Add(imageBorder);
                }

                Border removeBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 9,
                    Height = 200,
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    BorderBrush = Brushes.Gray,
                    CornerRadius = new CornerRadius(0, 25, 25, 0),
                    BorderThickness = new Thickness(1),
                };
                Label removeLabel = new Label()
                {
                    Content = "X",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                removeLabel.MouseLeftButtonDown += async (object sender, MouseButtonEventArgs e) => await RemoveHandler(lamp.Id);
                removeBorder.Child = removeLabel;
                lampPanel.Children.Add(removeBorder);

                lampViewPanel.Children.Add(lampPanel);
            }
        }

        private async Task RemoveHandler(long id)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(UILabels.CONFIRM_REMOVING, string.Empty, button);

            if (result == MessageBoxResult.Yes)
            {
                var response = await _lampService.Delete(id);
                if (response.IsError)
                {
                    MessageBox.Show(response.ErrorMessage);
                    return;
                }

                var panels = lampViewPanel.Children.OfType<StackPanel>();
                var panelToDelete = panels.FirstOrDefault(panel => panel.Name == $"panel_{id}");
                lampViewPanel.Children.Remove(panelToDelete);

                MessageBox.Show(Messages.DELETED_SUCCESSFULT_MESSAGE);
                return;
            }
        }
    }
}