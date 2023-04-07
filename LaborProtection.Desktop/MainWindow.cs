using LaborProtection.Localization;

namespace LaborProtection.Desktop
{
    public partial class MainWindow
    {
        private SharedLocalizer _sharedLocalizer;

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}