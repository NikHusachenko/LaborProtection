using LaborProtection.Localization;
using System.Windows;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        private readonly SharedLocalizer _sharedLocalizer;
        public string Message { get; set; }

        public MainWindow()
        {
            DataContext = this;

            _sharedLocalizer = new SharedLocalizer();
            Message = _sharedLocalizer["Calculation"];

            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show(_sharedLocalizer["Hello"]);
        }
    }
}
