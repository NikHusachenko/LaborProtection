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

// Work Are                             - 1
// Work Volume                          - 2

// Tables in width                      - 3
// Tables in length                     - 4
// Total tables count                   - 5

// Lamps in width                       - 6
// Lamps in length                      - 7
// Total lamps count                    - 8

// Bulbs in one lamp                    - 9
// Total bulbs count                    - 10

// Price on one lamp with bulbs         - 11
// Total price                          - 12