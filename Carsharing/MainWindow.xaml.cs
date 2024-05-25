using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TargetPage(Border border)
        {
            if (border == RectVisCars)
            {
                RectVisCars.BorderBrush = new SolidColorBrush(Color.FromRgb(146,146,146)); 
                RectVisTrips.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisService.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisClients.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisReport.BorderBrush = new SolidColorBrush(Colors.Transparent);

            } else if (border == RectVisTrips)
            {

                RectVisCars.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisTrips.BorderBrush = new SolidColorBrush(Color.FromRgb(146, 146, 146));
                RectVisService.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisClients.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisReport.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
            else if (border == RectVisService)
            {

                RectVisCars.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisTrips.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisService.BorderBrush = new SolidColorBrush(Color.FromRgb(146, 146, 146));
                RectVisClients.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisReport.BorderBrush = new SolidColorBrush(Colors.Transparent);
            } else if (border == RectVisClients)
            {
                RectVisCars.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisTrips.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisService.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisClients.BorderBrush = new SolidColorBrush(Color.FromRgb(146, 146, 146));
                RectVisReport.BorderBrush = new SolidColorBrush(Colors.Transparent);

            } else if (border == RectVisReport)
            {
                RectVisCars.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisTrips.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisService.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisClients.BorderBrush = new SolidColorBrush(Colors.Transparent);
                RectVisReport.BorderBrush = new SolidColorBrush(Color.FromRgb(146, 146, 146));
            }

        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void CarsButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Cars();
            TargetPage(RectVisCars);
            
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Trips();
            TargetPage(RectVisTrips);

        }

        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Service();
            TargetPage(RectVisService);
        }
        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Clients();
            TargetPage(RectVisClients);
        }
        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Reports();
            TargetPage(RectVisReport);
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
