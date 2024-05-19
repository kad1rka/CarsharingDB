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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для AddTrip.xaml
    /// </summary>
    public partial class AddTrip : Page
    {
        public AddTrip()
        {
            InitializeComponent();
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Trips());

        }
        private void Client_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(Client.Text, out int indexCar))
                {

                    var SearchObject = db.Клиенты
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Клиента == indexCar);
                    if (SearchObject != null)
                    {
                        SearchClient.Text = $"({SearchObject.ФИО})";
                    }
                    else
                    {
                        SearchClient.Text = "(Клиент не найден)";
                    }

                }

            }
        }


        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(Car.Text, out int indexCar))
                {

                    var SearchObject = db.Автомобили
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Автомобиля == indexCar);
                    if (SearchObject != null)
                    {
                        SearchCar.Text = $"({SearchObject.Модель})";
                    }
                    else
                    {
                        SearchCar.Text = "(Автомобиль не найден)";
                    }

                }

            }
        }

        private void Tariff_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(Tariff.Text, out int indexTariff))
                {

                    var SearchObject = db.Тарифы
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Тарифа == indexTariff);
                    if (SearchObject != null)
                    {
                        SearchTariff.Text = $"({SearchObject.Наименование})";
                    }
                    else
                    {
                        SearchTariff.Text = "(Тариф не найден)";
                    }

                }

            }
        }


        private void LocationStart_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(StartLocation.Text, out int indexLocation))
                {

                    var SearchObject = db.Локации_Парковочных_Мест
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Локации == indexLocation);
                    if (SearchObject != null)
                    {
                        SearchLocationStart.Text = $"({SearchObject.Описание})";
                    }
                    else
                    {
                        SearchLocationStart.Text = "(Локация не найдена)";
                    }

                }

            }
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

        private void LocationEnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(EndLocation.Text, out int indexLocation))
                {

                    var SearchObject = db.Локации_Парковочных_Мест
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Локации == indexLocation);
                    if (SearchObject != null)
                    {
                        SearchLocationEnd.Text = $"({SearchObject.Описание})";
                    }
                    else
                    {
                        SearchLocationEnd.Text = "(Локация не найдена)";
                    }

                }

            }
        }

        private void AddTripButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                string.IsNullOrEmpty(Car.Text) ||
                string.IsNullOrEmpty(Client.Text) ||
                string.IsNullOrEmpty(Tariff.Text) ||
                string.IsNullOrEmpty(StartLocation.Text) ||
                string.IsNullOrEmpty(EndLocation.Text) ||
                string.IsNullOrEmpty(End.Text) ||
                string.IsNullOrEmpty(Start.Text) ||
                string.IsNullOrEmpty(Price.Text) 
            )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var db = new dbCarsharing())
                {
                    Поездки Trip = new Поездки()
                    {
                        ID_Автомобиля = Convert.ToInt32(Car.Text),
                        ID_Клиента = Convert.ToInt32(Client.Text),
                        ID_Тарифа = Convert.ToInt32(Tariff.Text),
                        Стоимость = Convert.ToInt32(Price.Text),
                        ДатаВремя_Конца = Convert.ToDateTime(End.Text),
                        ДатаВремя_Начала = Convert.ToDateTime(Start.Text),
                        ID_Локации_Начала = Convert.ToInt32(StartLocation.Text),
                        ID_Локации_Конца = Convert.ToInt32(EndLocation.Text)
                        

                    };
                    db.Поездки.Add(Trip);
                    db.SaveChanges();
                    MessageBox.Show("Поездка успешно добавлено");
                    NavigationService.Navigate(new Trips());

                }
            }
        }
    }
}
