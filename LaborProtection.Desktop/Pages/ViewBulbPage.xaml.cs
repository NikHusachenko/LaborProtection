using LaborProtection.Services.BulbServices;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
    public partial class ViewBulbPage : Page
    {
        private readonly IBulbService _bulbService;

        public ViewBulbPage(IBulbService bulbService)
        {
            _bulbService = bulbService;

            InitializeComponent();
        }
    }
}