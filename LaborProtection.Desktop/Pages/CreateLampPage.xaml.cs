using FluentValidation;
using LaborProtection.Common;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LampServices.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LaborProtection.Desktop.Pages
{
    public partial class CreateLampPage : Page
    {
        private readonly ILampService _lampService;
        private readonly IValidator<CreateLampPostModel> _validator;

        private string _selectedImage = string.Empty;

        public CreateLampPage(ILampService lampService, 
            IValidator<CreateLampPostModel> validator)
        {
            _lampService = lampService;
            _validator = validator;

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
            _selectedImage = fileDialog.FileName;
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
                Image = new FileInfo(_selectedImage),
            };

            var modelState = await _validator.ValidateAsync(vm);
            
            if (!modelState.IsValid)
            {
                // Print errors
                return;
            }

            var result = await _lampService.Create(vm);
            if (result.IsError)
            {
                // Print error
                return;
            }
            MessageBox.Show(Messages.CREATE_DONE_MESSAGE);
            ClearFields();
        }

        private void ClearFields()
        {
            lampBulbCountTextBox.Text = string.Empty;
            lampHeightTextBox.Text = string.Empty;
            lampNameTextBox.Text = string.Empty;
            lampPriceTextBox.Text = string.Empty;
            lampTypeComboBox.SelectedIndex = 0;
        }
    }
}
