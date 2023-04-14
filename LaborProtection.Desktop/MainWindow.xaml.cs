using LaborProtection.Desktop.Pages;
using LaborProtection.EntityFramework;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        private readonly CreateBasePage _createBasePage;
        private readonly ViewComponentsPage _viewComponentsPage;

        public MainWindow(CreateBasePage createBasePage, 
            ViewComponentsPage viewComponentsPage)
        {
            _createBasePage = createBasePage;

            InitializeComponent();
            _viewComponentsPage = viewComponentsPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pagesFrame.Navigate(_createBasePage);
        }
        
		private void ViewBtn_Click(object sender, RoutedEventArgs e)
		{
            pagesFrame.Navigate(_viewComponentsPage);
		}

        public void Navigate(Page navigatePage)
        {
            pagesFrame.Navigate(_createBasePage);
        }
	}
}