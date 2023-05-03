using LaborProtection.Database.Entities;
using LaborProtection.Database.Enums;
using System.Windows;

namespace LaborProtection.Desktop.Windows.Views
{
    public partial class ViewBulbInformationWindow : Window
    {
        public ViewBulbInformationWindow(BulbEntity bulbEntity)
        {
            InitializeComponent();

            bulbNameValueLabel.Content = bulbEntity.Name;
            bulbIdValueLabel.Content = bulbEntity.Id;
            bulbTypeValueLabel.Content = BulbTypeDisplay.GetDisplayName(bulbEntity.Type);
            bulbVoltageValueLabel.Content = bulbEntity.Voltage;
            bulbPowerValueLabel.Content = bulbEntity.Power;
            bulbLightFluxValueLabel.Content = bulbEntity.LightFlux;
            bulbPriceValueLabel.Content = bulbEntity.Price;
        }
    }
}