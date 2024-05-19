﻿using System;
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
    /// Логика взаимодействия для AddTechnicalService.xaml
    /// </summary>
    public partial class AddTechnicalService : Page
    {
        public AddTechnicalService()
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
        private void Category_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new dbCarsharing())
            {
                if (int.TryParse(Category.Text, out int indexCategory))
                {

                    var SearchObject = db.Категории_Тех_Обслуживания
                        .AsNoTracking().
                        FirstOrDefault(c => c.ID_Категории_Тех_Обслуживание == indexCategory);
                    if (SearchObject != null)
                    {
                        SearchCategory.Text = $"({SearchObject.Наименование})";
                    }
                    else
                    {
                        SearchCategory.Text = "(Категория не найдена)";
                    }

                }



            }
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Service());

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

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {

            if (
                 string.IsNullOrEmpty(Model.Text) ||
                 string.IsNullOrEmpty(Category.Text) ||
                 string.IsNullOrEmpty(DateAndTime.Text) 
             )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Regex.IsMatch(DateAndTime.Text, @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$") & !string.IsNullOrEmpty(DateAndTime.Text))
            {

                MessageBox.Show("Дата рождения введена неверно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using (var db = new dbCarsharing())
                {
                    Техническое_Обслуживание Service = new Техническое_Обслуживание()
                    {
                        ID_Автомобиля = Convert.ToInt32(Model.Text),
                        ID_Категории_Тех_Обслуживания = Convert.ToInt32(Category.Text),
                        Дата = Convert.ToDateTime(DateAndTime.Text ),
                        Описание = Caption.Text

                    };
                    db.Техническое_Обслуживание.Add(Service);
                    db.SaveChanges();
                    MessageBox.Show("Запись успешно добавлена");
                    NavigationService.Navigate(new Service());
                }
            }
        }




    }
}
