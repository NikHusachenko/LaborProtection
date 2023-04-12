using LaborProtection.Desktop.Pages;
using LaborProtection.EntityFramework;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pagesFrame.Navigate(new CreateBasePage(new CreateLampPage()));
        }
		private void ViewBtn_Click(object sender, RoutedEventArgs e)
		{
            pagesFrame.Navigate(new ViewComponentsPage());
		}

        public void Navigate(Page navigatePage)
        {
            pagesFrame.Navigate(new CreateBasePage(navigatePage));
        }
	}
}