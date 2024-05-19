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
    /// Логика взаимодействия для AddPayments.xaml
    /// </summary>
    public partial class AddPayments : Page
    {
        public AddPayments()
        {
            InitializeComponent();
        }
        private void TextBox_PreviewTextInputDate(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) & c != '.' & c != ' ' & c != ':')
                {
                    e.Handled = true; // Отменяем ввод символа, если он не является строкой
                    return;
                }
            }
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
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Service());

        }

        private void Trip_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(Trip.Text, out int indexTrip))
                {

                    var SearchObject = db.Поездки
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Поездки == indexTrip);
                    if (SearchObject != null)
                    {
                        var car = db.Автомобили.AsNoTracking().FirstOrDefault(n => n.ID_Автомобиля == SearchObject.ID_Автомобиля);
                        SearchTrip.Text = $"({SearchObject.ДатаВремя_Конца} {car.Модель})";
                        Price.Text = SearchObject.Стоимость.ToString();
                        DateAndTime.Text = SearchObject.ДатаВремя_Конца.ToString();
                    }
                    else
                    {
                        SearchTrip.Text = "(Автомобиль не найден)";
                    }

                }

            }
        }

        private void AddPaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                 string.IsNullOrEmpty(Trip.Text) ||
                 string.IsNullOrEmpty(DateAndTime.Text) ||
                 string.IsNullOrEmpty(Price.Text)
             )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using (var db = new dbCarsharing())
                {
                    Оплата Payment = new Оплата()
                    {
                        ID_Поездки = Convert.ToInt32(Trip.Text),
                        ДатаВремя = Convert.ToDateTime(DateAndTime.Text),
                        Стоимость = Convert.ToDecimal(Price.Text)
                        

                    };
                    db.Оплата.Add(Payment);
                    db.SaveChanges();
                    MessageBox.Show("Запись успешно добавлена");
                    NavigationService.Navigate(new Clients());
                }
            }
        }
    }
}
