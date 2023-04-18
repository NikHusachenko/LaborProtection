using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages.Calculations
{
    public partial class CalculationBasePage : Page
    {
        private readonly CalculationAreaPage _calculationAreaPage;
        private readonly DrawingPage _drawingPage;
        private readonly Stack<Page> _pages;
        
        public CalculationBasePage(CalculationAreaPage calculationAreaPage,
            DrawingPage drawingPage)
        {
            _calculationAreaPage = calculationAreaPage;
            _drawingPage = drawingPage; 

            _pages = new Stack<Page>();
            _pages.Push(_calculationAreaPage);

            InitializeComponent();
        }

        private void calculationContainer_Loaded(object sender, RoutedEventArgs e)
        {
            calculationFrame.Navigate(_calculationAreaPage);
        }
    }
}
