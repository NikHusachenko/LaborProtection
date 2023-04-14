using LaborProtection.Database.Entities;
using LaborProtection.Services.LampServices;
using System;
using System.Windows;
using System.Windows.Controls;
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
            var lamps = await _lampService.GetAll();
            foreach (LampEntity lamp in lamps)
            {
                Border informationBorder = new Border()
                {
                    Width = lampViewContainer.Width / 3 * 2,
                    Height = 200,
                    Padding = new Thickness(10),
                };

                string lampInformation = $"{lamp.Id}\n{lamp.Name}\n{lamp.Type}\n{lamp.BulbCount}\n{lamp.Price}";
                TextBlock textBlock = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Text = lampInformation,
                };

                informationBorder.Child = textBlock;
                lampViewPanel.Children.Add(informationBorder);

                Border imageBorder = new Border()
                {
                    Width = lampViewContainer.Width / 3,
                    Height = 200,
                    Padding = new Thickness(10),
                };

                BitmapImage bitmap = new BitmapImage(new Uri(lamp.ImagePath));
                Image image = new Image()
                {
                    Source = bitmap,
                };

                imageBorder.Child = image;
                lampViewPanel.Children.Add(imageBorder);
            }
        }
    }
}