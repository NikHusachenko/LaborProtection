using LaborProtection.Common;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LampServices.Models;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LaborProtection.Desktop.Pages
{
    public partial class CreateLampPage : Page
    {
        private readonly ILampService _lampService;

        public CreateLampPage(ILampService lampService)
        {
            _lampService = lampService;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;

            if (fileDialog.ShowDialog() == true)
            {
                MessageBox.Show(fileDialog.FileName);
            }

            if (!fileDialog.CheckFileExists || 
                string.IsNullOrEmpty(fileDialog.FileName))
            {
                return;
            }
            
            BitmapImage image = new BitmapImage(new Uri(fileDialog.FileName));
            componentImage.Source = image;
        }

        private async void createLampButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ushort.TryParse(lampBulbCountTextBox.Text, out ushort bulbCount)) return;
            if (!float.TryParse(lampHeightTextBox.Text, out float height)) return;
            if (!float.TryParse(lampPriceTextBox.Text, out float price)) return;

            CreateLampPostModel vm = new CreateLampPostModel()
            {
                BulbCount = bulbCount,
                Height = height,
                Name = lampNameTextBox.Text,
                Price = price,
                Type = lampTypeComboBox.SelectedIndex + 1,
            };

            var validator = new CreateLampPostModelValidator();
            var modelState = await validator.ValidateAsync(vm);
            
            if (!modelState.IsValid)
            {
                // Print errors
                return;
            }

            MessageBox.Show(Messages.CREATE_DONE_MESSAGE); 
        }
    }
}
