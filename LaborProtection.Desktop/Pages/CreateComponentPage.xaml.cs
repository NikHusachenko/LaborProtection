using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtection.Desktop.Pages
{
    public partial class CreateComponentPage : Page
    {
        public CreateComponentPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == true)
            {
                MessageBox.Show(fileDialog.FileName);
            }
        }
    }
}
