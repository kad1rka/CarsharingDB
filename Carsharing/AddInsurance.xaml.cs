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
    /// Логика взаимодействия для AddInsurance.xaml
    /// </summary>
    public partial class AddInsurance : Page
    {
        public AddInsurance()
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
        private void TextBox_PreviewTextInputDate(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) & c != '.')
                {
                    e.Handled = true; // Отменяем ввод символа, если он не является строкой
                    return;
                }
            }
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cars());

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

        

        private void AddInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                string.IsNullOrEmpty(Model.Text) ||
                string.IsNullOrEmpty(StartDate.Text) ||
                string.IsNullOrEmpty(EndDate.Text)

            )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Regex.IsMatch(StartDate.Text, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") & !string.IsNullOrEmpty(StartDate.Text))
            {

                MessageBox.Show("Дата начала страхования введена неверно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Regex.IsMatch(EndDate.Text, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") & !string.IsNullOrEmpty(EndDate.Text))

            {
                MessageBox.Show("Дата конца страхования введена неверно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using (var db = new dbCarsharing())
                {
                    int ID_Insurance = Convert.ToInt32(db.Страховые_Данные.Max(n => n.ID_Автомобиля)) + 1;


                    Страховые_Данные Insurance = new Страховые_Данные()
                    {
                        ID_Страховки =  ID_Insurance.ToString(),
                        ID_Автомобиля = Convert.ToInt32(Model.Text),
                        ДатаНачалаСтрахования = Convert.ToDateTime(StartDate.Text),
                        ДатаКонцаСтрахования = Convert.ToDateTime(EndDate.Text),
                       
                    };
                    db.Страховые_Данные.Add(Insurance);
                    db.SaveChanges();
                    MessageBox.Show("Страховые данные успешно добавлены");
                    NavigationService.Navigate(new Cars());
                }
            }

        }
    }
}
