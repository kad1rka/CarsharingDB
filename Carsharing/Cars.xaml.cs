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
            locationsDataGrid.ItemsSource = dbCarsharing.GetContext().Локации_Парковочных_Мест.ToArray();
            countCarsRows.Text = dbCarsharing.GetContext().Автомобили.Count().ToString();
            countLocationsRows.Text = dbCarsharing.GetContext().Локации_Парковочных_Мест.Count().ToString();
            insuranceDataGrid.ItemsSource = dbCarsharing.GetContext().Страховые_Данные.ToArray();
            countInsuranceRows.Text = dbCarsharing.GetContext().Страховые_Данные.Count().ToString();

        }

        private void DeleteCarsButton_Click(object sender, RoutedEventArgs e)
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

        private void DeleteTariffButton_Click(object sender, RoutedEventArgs e)
        {
            var tariffForRemoving = carsDataGrid.SelectedItems.Cast<Автомобили>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {tariffForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Автомобили.RemoveRange(tariffForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    carsDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToList();

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
        private void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null)

            {
                if (cell.Column.Header != null)
                {
                    if (cell.Column.Header.ToString() == "номер автомобиля")
                    {

                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexCar))
                        {
                            string toolTipText = dbCarsharing.GetContext().Автомобили.FirstOrDefault(c => c.ID_Автомобиля == indexCar).Модель;
                            cell.ToolTip = toolTipText;
                        }
                    }

                }
            }

        }

        private void AddInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddInsurance());
        }

        private void AddCarsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCars());
        }

        private void AddLocationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddLocation());
        }

        private void SaveLocationsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    locationsDataGrid.ItemsSource = dbCarsharing.GetContext().Локации_Парковочных_Мест.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                locationsDataGrid.ItemsSource = dbCarsharing.GetContext().Локации_Парковочных_Мест.ToList();
            }
        }

        

        private void DeleteLocationButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = locationsDataGrid.SelectedItems.Cast<Локации_Парковочных_Мест>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Локации_Парковочных_Мест.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    locationsDataGrid.ItemsSource = dbCarsharing.GetContext().Локации_Парковочных_Мест.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void SaveInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    insuranceDataGrid.ItemsSource = dbCarsharing.GetContext().Страховые_Данные.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                insuranceDataGrid.ItemsSource = dbCarsharing.GetContext().Страховые_Данные.ToList();
            }
        }

        private void DeleteInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = insuranceDataGrid.SelectedItems.Cast<Страховые_Данные>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Страховые_Данные.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    insuranceDataGrid.ItemsSource = dbCarsharing.GetContext().Страховые_Данные.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
    }
}
