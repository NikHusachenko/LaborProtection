using FluentValidation;
using FluentValidation.Results;
using LaborProtection.Common;
using LaborProtection.Database.Enums;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LampServices.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LaborProtection.Desktop.Pages
{
    public partial class CreateLampPage : Page
    {
        private readonly ILampService _lampService;
        private readonly IValidator<CreateLampPostModel> _validator;

        private readonly MainWindow _parent;
        private readonly Dictionary<string, Label> _errorLabels;

        private string _selectedImage = string.Empty;

        public CreateLampPage(ILampService lampService, 
            IValidator<CreateLampPostModel> validator)
        {
            _lampService = lampService;
            _validator = validator;

            _parent = Window.GetWindow(this) as MainWindow;

            InitializeComponent();

            _errorLabels = new Dictionary<string, Label>();
            _errorLabels.Add("Name", lampNameErrorLabel);
            _errorLabels.Add("Type", lampTypeErrorLabel);
            _errorLabels.Add("Price", lampPriceErrorLabel);
            _errorLabels.Add("BulbCount", lampBulbCountErrorLabel);
            _errorLabels.Add("Height", lampHeightErrorLabel);
            _errorLabels.Add("Image", imageErrorLabel);
            
            foreach (var item in Enum.GetNames(typeof(LampType)))
            {
                lampTypeComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Images|*.png;*.jpg";
            fileDialog.ShowDialog();


            if (!fileDialog.CheckFileExists || 
                string.IsNullOrEmpty(fileDialog.FileName))
            {
                SetSpecificError(imageErrorLabel, Errors.IMAGE_NOT_SELECTED, Brushes.Red, Visibility.Visible); 
                return;
            }
            
            BitmapImage image = new BitmapImage(new Uri(fileDialog.FileName));
            _selectedImage = fileDialog.FileName;
            componentImage.Source = image;
        }

        private async void createLampButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ushort.TryParse(lampBulbCountTextBox.Text, out ushort bulbCount))
            {
                SetSpecificError(lampBulbCountErrorLabel, Errors.INVALIDA_VALUE_ERROR, Brushes.Red, Visibility.Visible);
                return;
            }
            if (!float.TryParse(lampHeightTextBox.Text, out float height))
            {
                SetSpecificError(lampHeightErrorLabel, Errors.INVALIDA_VALUE_ERROR, Brushes.Red, Visibility.Visible);
            }
            if (!float.TryParse(lampPriceTextBox.Text, out float price))
            {
                SetSpecificError(lampPriceErrorLabel, Errors.INVALIDA_VALUE_ERROR, Brushes.Red, Visibility.Visible);
            }

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
                ICollection<ValidationFailure> errors = modelState.Errors;
                foreach (ValidationFailure error in errors)
                {
                    SetSpecificError(_errorLabels[error.PropertyName], error.ErrorMessage, Brushes.Red, Visibility.Visible);
                }
                return;
            }

            var result = await _lampService.Create(vm);
            if (result.IsError)
            {
                _parent.SetGlobalErrorMessage(result.ErrorMessage, Brushes.Red, Visibility.Visible);
                return;
            }
            MessageBox.Show(Messages.CREATE_DONE_MESSAGE);
            ClearFields();
        }

        private void SetSpecificError(Label target, string errorMessage, Brush messageColor, Visibility visibility)
        {
            target.Content = errorMessage;
            target.Foreground = messageColor;
            target.Visibility = visibility;
        }

        private void ClearFields()
        {
            lampBulbCountTextBox.Text = string.Empty;
            lampHeightTextBox.Text = string.Empty;
            lampNameTextBox.Text = string.Empty;
            lampPriceTextBox.Text = string.Empty;
            lampTypeComboBox.SelectedIndex = 0;

            _selectedImage = string.Empty;
            componentImage.Source = null;
        }
    }
}
