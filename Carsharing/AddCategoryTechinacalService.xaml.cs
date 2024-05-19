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
    /// Логика взаимодействия для AddCategoryTechinacalService.xaml
    /// </summary>
    public partial class AddCategoryTechinacalService : Page
    {
        public AddCategoryTechinacalService()
        {
            InitializeComponent();
        }

        private void AddCategoryServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                 string.IsNullOrEmpty(Name.Text) 
            )
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                using (var db = new dbCarsharing())
                {
                    Категории_Тех_Обслуживания Category = new Категории_Тех_Обслуживания()
                    {
                        Наименование = Name.Text,
                        
                        Описание = Caption.Text

                    };
                    db.Категории_Тех_Обслуживания.Add(Category);
                    db.SaveChanges();
                    MessageBox.Show("Запись успешно добавлена");
                    NavigationService.Navigate(new Service());
                }
            }
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Service());

        }
    }
}
