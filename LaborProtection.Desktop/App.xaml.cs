using LaborProtection.Localization;
using System.Globalization;
using System.Windows;

namespace LaborProtection.Desktop
{
    public partial class App : Application
    {
        public App()
        {
            LocalizationConfigurationManager.RegisterCulture(new CultureInfo("ua-UA"), typeof(ua_UA));
            LocalizationConfigurationManager.RegisterCulture(new CultureInfo("en-EN"), typeof(en_EN));
            LocalizationConfigurationManager.RegisterCulture(new CultureInfo("ru-RU"), typeof(ru_RU));
            LocalizationConfigurationManager.SetDefaultCulture(new CultureInfo("en-EN"), null);
        }
    }
}
