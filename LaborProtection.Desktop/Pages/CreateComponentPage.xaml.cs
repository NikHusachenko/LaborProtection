using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            fileDialog.Multiselect = false;

            if (fileDialog.ShowDialog() == true)
            {
                MessageBox.Show(fileDialog.FileName);
            }

            if (!fileDialog.CheckFileExists || 
                string.IsNullOrEmpty(fileDialog.FileName))
            {
                return;
            }

            var a1 = fileDialog.FileName;

            BitmapImage image = new BitmapImage(new Uri(fileDialog.FileName));
            componentImage.Source = image;
        }
    }
}
