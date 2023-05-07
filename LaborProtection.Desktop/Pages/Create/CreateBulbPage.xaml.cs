using FluentValidation;
using FluentValidation.Results;
using LaborProtection.Common;
using LaborProtection.Database.Enums;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.BulbServices.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaborProtection.Desktop.Pages
{
    public partial class CreateBulbPage : Page
    {
        private readonly IBulbService _bulbService;
        private readonly IValidator<CreateBulbPostModel> _validator;
        private readonly MainWindow _parent;
        
        private readonly Dictionary<string, Label> _entityPropertyErrorLabels;

        public CreateBulbPage(IBulbService bulbService,
            IValidator<CreateBulbPostModel> validator)
        {
            _bulbService = bulbService;
            _validator = validator;
            _parent = Window.GetWindow(this) as MainWindow;
            
            InitializeComponent();

            foreach (var item in Enum.GetNames(typeof(BulbType)))
            {
                bulbTypeComboBox.Items.Add(item);
            }

            _entityPropertyErrorLabels = new Dictionary<string, Label>();
            _entityPropertyErrorLabels.Add("Name", bulbNameErrorLabel);
            _entityPropertyErrorLabels.Add("Type", bulbTypeErrorLabel);
            _entityPropertyErrorLabels.Add("Voltage", bulbVoltageErrorLabel);
            _entityPropertyErrorLabels.Add("Power", bulbPowerErrorLabel);
            _entityPropertyErrorLabels.Add("LightFlux", bulbLightFluxErrorLabel);
            _entityPropertyErrorLabels.Add("Price", bulbPriceErrorLabel);
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            

            if (!int.TryParse(bulbLightFluxTextBox.Text, out int lightFlux))
            {
                SetSpecificError(bulbLightFluxErrorLabel, Errors.INVALID_VALUE_ERROR, Brushes.Red, Visibility.Visible);
                return;
            }
            if (!short.TryParse(bulbPowerTextBox.Text, out short power))
            {
                SetSpecificError(bulbPowerErrorLabel, Errors.INVALID_VALUE_ERROR, Brushes.Red, Visibility.Visible);
                return;
            }
            if (!float.TryParse(bulbPriceTextBox.Text, out float price))
            {
                SetSpecificError(bulbPriceErrorLabel, Errors.INVALID_VALUE_ERROR, Brushes.Red, Visibility.Visible);
                return;
            }
            if (!short.TryParse(bulbVoltageTextBox.Text, out short voltage))
            {
                SetSpecificError(bulbVoltageErrorLabel, Errors.INVALID_VALUE_ERROR, Brushes.Red, Visibility.Visible);
                return;
            }

            CreateBulbPostModel vm = new CreateBulbPostModel()
            {
                LightFlux = lightFlux,
                Name = bulbNameTextBox.Text,
                Power = power,
                Price = price,
                Type = bulbTypeComboBox.SelectedIndex + 1,
                Voltage = voltage,
            };

            var modelState = await _validator.ValidateAsync(vm);
            if (!modelState.IsValid)
            {
                ICollection<ValidationFailure> errors = modelState.Errors;
                foreach (ValidationFailure error in errors)
                {
                    SetSpecificError(_entityPropertyErrorLabels[error.PropertyName], error.ErrorMessage, Brushes.Red, Visibility.Visible);
                }
                return;
            }

            var response = await _bulbService.Create(vm);
            if (response.IsError)
            {
                if (_parent == null)
                {
                    throw new Exception(Errors.CAN_NOT_GET_PARENT_ERROR);
                }
                _parent.SetGlobalErrorMessage(response.ErrorMessage, Brushes.Red, Visibility.Visible);
                return;
            }
            MessageBox.Show(Messages.CREATED_SUCCESSFULY_MESSAGE);
            ClearFields();
        }
        
        private void SetSpecificError(Label target, string errorMessage, Brush messageColor, Visibility isVisible)
        {
            target.Content = errorMessage;
            target.Foreground = messageColor;
            target.Visibility = isVisible;
        }

        private void ClearErrors()
        {
            bulbLightFluxErrorLabel.Content = string.Empty;
            bulbNameErrorLabel.Content = string.Empty;
            bulbPowerErrorLabel.Content = string.Empty;
            bulbPriceErrorLabel.Content = string.Empty;
            bulbTypeErrorLabel.Content = string.Empty;
            bulbVoltageErrorLabel.Content = string.Empty;
            _parent.SetGlobalErrorMessage(string.Empty, null);
        }

        private void ClearFields()
        {
            bulbLightFluxTextBox.Text = string.Empty;
            bulbNameTextBox.Text = string.Empty;
            bulbPowerTextBox.Text = string.Empty;
            bulbPriceTextBox.Text = string.Empty;
            bulbTypeComboBox.SelectedIndex = 0;
            bulbVoltageTextBox.Text = string.Empty;
        }
    }
}