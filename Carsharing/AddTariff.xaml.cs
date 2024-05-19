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
    /// Логика взаимодействия для AddTariff.xaml
    /// </summary>
    public partial class AddTariff : Page
    {
        public AddTariff()
        {
            InitializeComponent();
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Clients());

        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true; // Отменяем ввод символа, если он не является цифрой
                    return;
                }
            }
        }
        private void TextBox_PreviewTextInputChar(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true; // Отменяем ввод символа, если он не является буквой
                    return;
                }
            }
        }

        

        private void AddTariffButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                 string.IsNullOrEmpty(Name.Text) ||
                 string.IsNullOrEmpty(Price.Text) ||
                 string.IsNullOrEmpty(Experience.Text) ||
                 string.IsNullOrEmpty(Age.Text) 

             )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using (var db = new dbCarsharing())
                {
                    Тарифы Tariff = new Тарифы()
                    {
                        Наименование = Name.Text,
                        Мин_Возраст = Convert.ToInt32(Age.Text),
                        Мин_Стаж = Convert.ToInt32(Experience.Text),
                        Стоимость = Convert.ToDecimal(Price.Text)
                    };
                    db.Тарифы.Add(Tariff);
                    db.SaveChanges();
                    MessageBox.Show("Тариф успешно добавлен");
                    NavigationService.Navigate(new Clients());
                }
            }

        }
    }
}
