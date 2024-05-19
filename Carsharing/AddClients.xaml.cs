using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Page
    {
        public AddClients()
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

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {

            if (
                 string.IsNullOrEmpty(FIO.Text) ||
                 string.IsNullOrEmpty(Year.Text) ||
                 string.IsNullOrEmpty(Telephone.Text) ||
                 string.IsNullOrEmpty(Email.Text) ||
                 string.IsNullOrEmpty(LicenseNumber.Text) ||
                 string.IsNullOrEmpty(LicenseDate.Text) ||
                 string.IsNullOrEmpty(NumberPassport.Text) 

             ) 
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Regex.IsMatch(Year.Text, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") & !string.IsNullOrEmpty(Year.Text))
            {
                
                MessageBox.Show("Дата рождения введена неверно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Regex.IsMatch(LicenseDate.Text, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") & !string.IsNullOrEmpty(LicenseDate.Text))

            {
                MessageBox.Show("Дата выдачи В.У. введена неверно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using (var db = new dbCarsharing())
                {
                    Клиенты Client = new Клиенты()
                    {
                        ФИО = FIO.Text,
                        Дата_Выдачи_ВУ = Convert.ToDateTime(LicenseDate.Text),
                        Дата_Рождения = Convert.ToDateTime(Year.Text),
                        Номер_ВУ = LicenseNumber.Text,
                        НомерСерия_Паспорта = NumberPassport.Text,
                        Телефон = Telephone.Text,
                        Почта = Email.Text

                    };
                    db.Клиенты.Add(Client);
                    db.SaveChanges();
                    MessageBox.Show("Клиент успешно добавлен");
                    NavigationService.Navigate(new Clients());
                }
            }
        }
    }
}
