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
    /// Логика взаимодействия для AddDTP.xaml
    /// </summary>
    public partial class AddDTP : Page
    {
        public AddDTP()
        {
            InitializeComponent();
        }

        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(Model.Text, out int indexCar))
                {

                    var SearchObject = db.Автомобили
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Автомобиля == indexCar);
                    if (SearchObject != null)
                    {
                        SearchModel.Text = $"({SearchObject.Модель})";
                    }
                    else
                    {
                        SearchModel.Text = "(Автомобиль не найден)";
                    }

                }

            }
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
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Service());

        }
        private void TextBox_PreviewTextInputDate(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) & c != '.' & c != ' ' & c!= ':')
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

        private void AddDTP_Click(object sender, RoutedEventArgs e)
        {
            if (
                string.IsNullOrEmpty(Model.Text) ||
                string.IsNullOrEmpty(Client.Text) ||
                string.IsNullOrEmpty(DateAndTime.Text)
            )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var db = new dbCarsharing())
                {
                    ДТП DTP = new ДТП()
                    {
                        ID_Автомобиля = Convert.ToInt32(Model.Text),
                        ID_Клиента = Convert.ToInt32( Client.Text),
                        Дата = Convert.ToDateTime(DateAndTime.Text),
                        Описание = Caption.Text
                       
                    };
                    db.ДТП.Add(DTP);
                    db.SaveChanges();
                    MessageBox.Show("ДТП успешно добавлено" );
                    NavigationService.Navigate(new Service());

                }
            }

        }
    }
}
