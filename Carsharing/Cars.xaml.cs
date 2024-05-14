using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        public Cars()
        {
            InitializeComponent();
            carsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToArray();
            countRows.Text = dbCarsharing.GetContext().Автомобили.Count().ToString();
              
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = carsDataGrid.SelectedItems.Cast<Автомобили>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {usersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Автомобили.RemoveRange(usersForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    carsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToList();
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        { 
            try
            {

                using (var dbContext = new dbCarsharing())
                {
                    
                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно обновлены", "Обновление данных", MessageBoxButton.OK);
                    carsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка",MessageBoxButton.OK, MessageBoxImage.Warning);
                carsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToList();
            }
                
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {
                    
                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    carsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                carsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToList();
            }

        }
    }
}
