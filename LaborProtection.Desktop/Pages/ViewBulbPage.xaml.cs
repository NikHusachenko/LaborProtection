using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Services.BulbServices;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private async void bulbViewPanel_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            bulbViewPanel.Children.Clear();

            ICollection<BulbEntity> bulbs = await _bulbService.GetAll();
            foreach (BulbEntity bulb in bulbs)
            {
                Border bulbBorder = new Border()
                {
                    Width = bulbViewContainer.ActualWidth,
                    Margin = new Thickness(10),
                    Name = $"container_{bulb.Id}"
                };

                Grid informationContainer = new Grid();
                informationContainer.ColumnDefinitions.Add(new ColumnDefinition());
                informationContainer.ColumnDefinitions.Add(new ColumnDefinition());
                informationContainer.ColumnDefinitions.Add(new ColumnDefinition());
                informationContainer.ColumnDefinitions.Add(new ColumnDefinition());
                informationContainer.ColumnDefinitions.Add(new ColumnDefinition());
                informationContainer.ColumnDefinitions.Add(new ColumnDefinition());

                Label idLabel = new Label()
                {
                    Content = bulb.Id,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                Grid.SetColumn(idLabel, 0);
                informationContainer.Children.Add(idLabel);

                Label nameLabel = new Label()
                {
                    Content = bulb.Name,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                Grid.SetColumn(nameLabel, 1);
                informationContainer.Children.Add(nameLabel);

                Label powerLabel = new Label()
                {
                    Content = bulb.Power,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment= VerticalAlignment.Center,
                };
                Grid.SetColumn(powerLabel, 2);
                informationContainer.Children.Add(powerLabel);

                Label priceLabel = new Label()
                {
                    Content = bulb.Price,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                Grid.SetColumn(priceLabel, 3);
                informationContainer.Children.Add(priceLabel);

                Label lightFluxLabel = new Label()
                {
                    Content = bulb.LightFlux,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                Grid.SetColumn(lightFluxLabel, 4);
                informationContainer.Children.Add(lightFluxLabel);

                Label removeBulbLabel = new Label()
                {
                    Content = "X",
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
                removeBulbLabel.MouseLeftButtonDown += (object sender, MouseButtonEventArgs e) => RemoveBulb(bulb.Id);
                Grid.SetColumn(removeBulbLabel, 5);
                informationContainer.Children.Add(removeBulbLabel);

                bulbBorder.Child = informationContainer;
                bulbViewPanel.Children.Add(bulbBorder);
            }
        }

        private async void RemoveBulb(long id)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(UILabels.CONFIRM_REMOVING, "Caption qwerty", button);
            if (result == MessageBoxResult.Yes)
            {
                var response = await _bulbService.Delete(id);
                if (response.IsError)
                {
                    MessageBox.Show(response.ErrorMessage);
                    return;
                }

                MessageBox.Show(Messages.DELETED_SUCCESSFULT_MESSAGE);
                var borders = bulbViewPanel.Children.OfType<Border>();
                var borderToDelete = borders.FirstOrDefault(grid => grid.Name == $"container_{id}");
                bulbViewPanel.Children.Remove(borderToDelete);
            }
        }
    }
}