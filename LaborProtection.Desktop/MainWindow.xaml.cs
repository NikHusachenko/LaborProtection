using LaborProtection.Desktop.Pages;
using LaborProtection.Localization;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox languagePicker = sender as ComboBox;
            ComboBoxItem item = languagePicker.SelectedItem as ComboBoxItem;

            string culture = LocalizationConfigurationManager.DefaultCulture.Name;
            if (item.Content != null)
            {
                culture = item.Content.ToString();
            }

            _sharedLocalizer = LocalizationConfigurationManager.SwitchLocale(culture);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pagesFrame.Navigate(new CreateComponentPage());
        }

		private void ViewBtn_Click(object sender, RoutedEventArgs e)
		{
            pagesFrame.Navigate(new ViewComponentsPage());
		}
	}
}
