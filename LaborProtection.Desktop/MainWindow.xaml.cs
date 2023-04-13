using LaborProtection.Desktop.Pages;
using LaborProtection.EntityFramework;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        private readonly CreateBasePage _createBasePage;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(CreateBasePage createBasePage) : this()
        {
            _createBasePage = createBasePage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pagesFrame.Navigate(_createBasePage);
        }
        
		private void ViewBtn_Click(object sender, RoutedEventArgs e)
		{
            pagesFrame.Navigate(new ViewComponentsPage());
		}

        public void Navigate(Page navigatePage)
        {
            pagesFrame.Navigate(_createBasePage);
        }
	}
}