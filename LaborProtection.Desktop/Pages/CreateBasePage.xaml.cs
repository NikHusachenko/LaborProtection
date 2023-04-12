using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
	public partial class CreateBasePage : Page
	{
		public CreateBasePage(Page renderPage)
		{
			InitializeComponent();
		}

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            /*var parent = Window.GetWindow(this) as MainWindow;
			if (parent != null)
			{
				parent.Navigate(new CreateBasePage(new CreateLampPage()));
			}*/

            createFrame.Navigate(new CreateLampPage());
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            /*var parent = Window.GetWindow(this) as MainWindow;
            if (parent != null)
            {
                parent.Navigate(new CreateBasePage(new CreateBulbPage()));
            }*/
            createFrame.Navigate(new CreateBulbPage());
        }
    }
}