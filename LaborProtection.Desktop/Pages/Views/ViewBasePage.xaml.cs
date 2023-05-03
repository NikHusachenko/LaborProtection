using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
    public partial class ViewBasePage : Page
    {
        private readonly ILampService _lampService;
        private readonly IBulbService _bulbService;

        public ViewBasePage(ILampService lampService,
            IBulbService bulbService)
        {
            _lampService = lampService;
            _bulbService = bulbService;

            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            viewFrame.Navigate(new ViewBulbPage(_bulbService));
        }

        private void RadioButton_Checked_1(object sender, System.Windows.RoutedEventArgs e)
        {
            viewFrame.Navigate(new ViewLampPage(_lampService));
        }
    }
}