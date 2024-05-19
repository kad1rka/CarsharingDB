using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Page
    {
        public AddLocation()
        {
            InitializeComponent();
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c!=',')
                {
                    e.Handled = true; // Отменяем ввод символа, если он не является цифрой
                    return;
                }
            }
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cars());

        }

        

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
           
            if (
                    string.IsNullOrEmpty(Longitude.Text) ||
                    string.IsNullOrEmpty(Latitude.Text) 
                    
                )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var db = new dbCarsharing())
                {
                    Локации_Парковочных_Мест Location = new Локации_Парковочных_Мест()
                    {
                       Долгота  = Convert.ToDecimal(Longitude.Text),
                       Широта = Convert.ToDecimal(Latitude.Text),
                       Описание = Caption.Text

                    };
                    db.Локации_Парковочных_Мест.Add(Location);
                    db.SaveChanges();
                    MessageBox.Show("Локация успешно добавлена");
                    NavigationService.Navigate(new Cars().tabControl.SelectedIndex=2);
                }
            }


            
        }
    }
}
