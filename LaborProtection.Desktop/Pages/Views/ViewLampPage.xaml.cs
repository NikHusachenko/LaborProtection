using LaborProtection.Common;
using LaborProtection.Database.Entities;
using LaborProtection.Services.LampServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LaborProtection.Desktop.Pages
{
    public partial class ViewLampPage : Page
    {
        private readonly ILampService _lampService;

        public ViewLampPage(ILampService lampService)
        {
            _lampService = lampService;

            InitializeComponent();
        }

        private async void lampViewPanel_Loaded(object sender, RoutedEventArgs e)
        {
            lampViewPanel.Children.Clear();

            ICollection<LampEntity> lamps = await _lampService.GetAll();
            foreach (LampEntity lamp in lamps)
            {
                StackPanel lampPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Width = lampViewContainer.ActualWidth,
                    Height = 200,
                    Margin = new Thickness(0, 0, 0, 10),
                    Name = $"panel_{lamp.Id}",
                };

                Border informationBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 9 * 4,
                    Height = 200,
                    Padding = new Thickness(10),
                    BorderBrush = Brushes.Gray,
                    CornerRadius = new CornerRadius(25, 0, 0, 25),
                    BorderThickness = new Thickness(1),
                };
                
                TextBlock textBlock = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Text = $"Id:\t{lamp.Id}\nНазва:\t{lamp.Name}\nТип:\t{lamp.Type}\nКількість лампочок:\t{lamp.BulbCount}\nЦіна:\t{lamp.Price}",
                    FontSize = 22,
                };
                informationBorder.Child = textBlock;
                lampPanel.Children.Add(informationBorder);

                Border imageBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 9 * 4,
                    Height = 200,
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    BorderBrush = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                };

                if (File.Exists(lamp.ImagePath))
                {
                    BitmapImage bitmap;

                    bitmap = new BitmapImage(new Uri(Path.GetFullPath(lamp.ImagePath)));

                    Image image = new Image()
                    {
                        Source = bitmap,
                        Name = $"image{lamp.Id}",
                    };
                    imageBorder.Child = image;
                    lampPanel.Children.Add(imageBorder);
                }

                Border removeBorder = new Border()
                {
                    Width = lampViewContainer.ActualWidth / 9,
                    Height = 200,
                    Padding = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    BorderBrush = Brushes.Gray,
                    CornerRadius = new CornerRadius(0, 25, 25, 0),
                    BorderThickness = new Thickness(1),
                };
                Label removeLabel = new Label()
                {
                    Content = "X",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                removeLabel.MouseLeftButtonDown += async (object sender, MouseButtonEventArgs e) => await RemoveHandler(lamp.Id, $"image{lamp.Id}");
                removeBorder.Child = removeLabel;
                lampPanel.Children.Add(removeBorder);

                lampViewPanel.Children.Add(lampPanel);
            }
        }

        private async Task RemoveHandler(long id, string imageName)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(UILabels.CONFIRM_REMOVING, string.Empty, button);

            if (result == MessageBoxResult.Yes)
            {
                Image imageToDelete = FindChild<Image>(this, imageName);
                if (imageToDelete == null)
                {
                    return;
                }

                imageToDelete.Source = null;
                var response = await _lampService.Delete(id);
                if (response.IsError)
                {
                    MessageBox.Show(response.ErrorMessage);
                    return;
                }

                var panels = lampViewPanel.Children.OfType<StackPanel>();
                var panelToDelete = panels.FirstOrDefault(panel => panel.Name == $"panel_{id}");
                lampViewPanel.Children.Remove(panelToDelete);

                MessageBox.Show(Messages.DELETED_SUCCESSFULT_MESSAGE);
                return;
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child != null && child is T && child.GetValue(FrameworkElement.NameProperty) as string == childName)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindChild<T>(child, childName);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

    }
}