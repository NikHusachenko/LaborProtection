using LaborProtection.Common;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.BulbServices.Models;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
    public partial class CreateBulbPage : Page
    {
        private readonly IBulbService _bulbService;
        private readonly CreateBulbPostModelValidator _validator;

        public CreateBulbPage(IBulbService bulbService,
            CreateBulbPostModelValidator validator)
        {
            _bulbService = bulbService;
            _validator = validator;

            InitializeComponent();
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!int.TryParse(bulbLightFluxTextBox.Text, out int lightFlux)) return;
            if (!short.TryParse(bulbPowerTextBox.Text, out short power)) return;
            if (!float.TryParse(bulbPriceTextBox.Text, out float price)) return;
            if (!short.TryParse(bulbVoltageTextBox.Text, out short voltage)) return;

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
                // Print errors
                return;
            }

            var response = await _bulbService.Create(vm);
            if (response.IsError)
            {
                // Print Error
                return;
            }
            MessageBox.Show(Messages.CREATE_DONE_MESSAGE);
            ClearFields();
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