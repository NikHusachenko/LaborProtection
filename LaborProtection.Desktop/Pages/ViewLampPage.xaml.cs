using LaborProtection.Database.Entities;
using LaborProtection.Services.LampServices;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
                };

                Border informationBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 3 * 2,
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
                    Width = lampViewContainer.ActualWidth / 3,
                    Height = 200,
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    BorderBrush = Brushes.Gray,
                    CornerRadius = new CornerRadius(0, 25, 25, 0),
                    BorderThickness = new Thickness(1),
                };

                BitmapImage bitmap = new BitmapImage(new Uri(lamp.ImagePath));
                Image image = new Image()
                {
                    Source = bitmap,
                };

                imageBorder.Child = image;
                lampPanel.Children.Add(imageBorder);

                lampViewPanel.Children.Add(lampPanel);
            }
        }
    }
}