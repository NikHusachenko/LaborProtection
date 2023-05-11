using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LaborProtection.Desktop.Windows.Views
{
    public partial class ViewLampInformationWindow : Window
    {
        public ViewLampInformationWindow(LampEntity lampEntity)
        {
            InitializeComponent();

            lampIdValueLabel.Content = lampEntity.Id;
            lampNameValueLabel.Content = lampEntity.Name;
            lampTypeValueLabel.Content = LampTypeDisplay.GetDisplayName(lampEntity.Type);
            lampPriceValueLabel.Content = lampEntity.Price;
            lampBulbCountValueLabel.Content = lampEntity.BulbCount;
            lampHeightValueLabel.Content = lampEntity.Height;

            if (File.Exists(Path.GetFullPath(lampEntity.ImagePath)))
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(Path.GetFullPath(lampEntity.ImagePath)));
                lampDisplayImage.Source = bitmapImage;
            }
        }
    }
}