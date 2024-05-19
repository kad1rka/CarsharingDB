using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Text.RegularExpressions;
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для AddCars.xaml
    /// </summary>
    public partial class AddCars : Page
    {

        public AddCars()
        {
            InitializeComponent();
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


        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*using (var db = new dbCarsharing())
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



            }*/
        }
        private void TextBox_PreviewTextInputChar(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true; // Отменяем ввод символа, если он не является строкой
                    return;
                }
            }
        }
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
           if (
                string.IsNullOrEmpty(Model.Text) ||
                string.IsNullOrEmpty(Year.Text) ||
                string.IsNullOrEmpty(VIN.Text) ||
                string.IsNullOrEmpty(Number.Text)
            )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Regex.IsMatch(Number.Text, @"[АВЕКМНОРСТУХ]\d{3}(?<!000)[АВЕКМНОРСТУХ]{2}\d{2,3}") & !string.IsNullOrEmpty(Number.Text))
            {
                MessageBox.Show("Номер не является действительным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                using (var db = new dbCarsharing())
                {
                    Автомобили Car = new Автомобили()
                    {
                        Модель = Model.Text,
                        VIN_Номер = VIN.Text,
                        Год_Выпуска = Convert.ToInt32(Year.Text),
                        Номер = Number.Text,
                        Описание = Caption.Text
                        
                    };
                    db.Автомобили.Add( Car );
                    db.SaveChanges();
                    MessageBox.Show("Автомобиль успешно добавлен");
                    NavigationService.Navigate(new Cars());
                    
                }
            }

            
        }
    }
}
