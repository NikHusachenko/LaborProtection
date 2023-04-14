using LaborProtection.Services.LampServices;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
    public partial class ViewLampPage : Page
    {
        private readonly ILampService _lampService;

        public ViewLampPage(ILampService lampService)
        {
            _lampService = lampService;

            InitializeComponent();
        }

        
    }
}
