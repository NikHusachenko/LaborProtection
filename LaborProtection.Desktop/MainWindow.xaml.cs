﻿using LaborProtection.Desktop.Pages;
using System.Windows;
using System.Windows.Media;

namespace LaborProtection.Desktop
{
    public partial class MainWindow : Window
    {
        private readonly CreateBasePage _createBasePage;
        private readonly ViewBasePage _viewBasePage;

        public MainWindow(CreateBasePage createBasePage, 
            ViewBasePage viewBasePage)
        {
            _createBasePage = createBasePage;
            _viewBasePage = viewBasePage;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pagesFrame.Navigate(_createBasePage);
        }
        
		private void ViewBtn_Click(object sender, RoutedEventArgs e)
		{
            pagesFrame.Navigate(_viewBasePage);
		}

        public void SetGlobalErrorMessage(string message, Brush brush, Visibility isVisible = Visibility.Visible)
        {
            globalErrorLabel.Foreground = brush;
            globalErrorLabel.Content = message;
            globalErrorLabel.Visibility = isVisible;
        }
	}
}