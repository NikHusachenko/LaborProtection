using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
	public partial class CreateBasePage : Page
	{
        private readonly CreateLampPage _createLampPage;
        private readonly CreateBulbPage _createBulbPage;

		public CreateBasePage(CreateLampPage createLampPage,
            CreateBulbPage createBulbPage)
		{
            _createLampPage = createLampPage;
            _createBulbPage = createBulbPage;

			InitializeComponent();
		}

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            createFrame.Navigate(_createBulbPage);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            createFrame.Navigate(_createLampPage);
        }
    }
}