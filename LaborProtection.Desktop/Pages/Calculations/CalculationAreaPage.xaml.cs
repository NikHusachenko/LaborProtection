using LaborProtection.Services.CalculationServices;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages.Calculations
{
    public partial class CalculationAreaPage : Page
    {
        private readonly ICalculationService _calculationService;

        public CalculationAreaPage(ICalculationService calculationService)
        {
            _calculationService = calculationService;

            InitializeComponent();
        }
    }
}
