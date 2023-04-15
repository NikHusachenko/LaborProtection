using LaborProtection.Database.Entities;
using LaborProtection.Services.BulbServices;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            ICollection<BulbEntity> bulbs = await _bulbService.GetAll();
            foreach (BulbEntity bulb in bulbs)
            {
                Border bulbBorder = new Border()
                {
                    Width = bulbViewContainer.ActualWidth,
                    Height = 200,
                    Margin = new Thickness(10),
                };

                TextBlock informationBlock = new TextBlock()
                {
                    Text = $"{bulb.Id}\n{bulb.Name}\n{bulb.Power}\n{bulb.Price}\n{bulb.LightFlux}",
                    FontSize = 24,
                };

                bulbBorder.Child = informationBlock;
                bulbViewContainer.Children.Add(bulbBorder);
            }
        }
    }
}