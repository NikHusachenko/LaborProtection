using LaborProtection.Desktop.Pages;
using LaborProtection.EntityFramework;
using System.Windows;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

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