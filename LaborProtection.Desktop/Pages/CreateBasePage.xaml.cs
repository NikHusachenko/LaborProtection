using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
	public partial class CreateBasePage : Page
	{
        private readonly CreateLampPage _createLampPage;

		public CreateBasePage(CreateLampPage createLampPage)
		{
            _createLampPage = createLampPage;

			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createFrame.Navigate(_createLampPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            createFrame.Navigate(new CreateBulbPage());
        }
    }
}