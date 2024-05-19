using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
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
using static System.Net.Mime.MediaTypeNames;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        public Service()
        {
            InitializeComponent();
            dtpDataGrid.ItemsSource = dbCarsharing.GetContext().ДТП.ToArray();
            serviceDataGrid.ItemsSource = dbCarsharing.GetContext().Техническое_Обслуживание.ToArray();
            categoryDataGrid.ItemsSource = dbCarsharing.GetContext().Категории_Тех_Обслуживания.ToArray();
            countDTPRows.Text = dbCarsharing.GetContext().ДТП.Count().ToString();
            countServiceRows.Text = dbCarsharing.GetContext().Техническое_Обслуживание.Count().ToString();
            countСategoryRows.Text = dbCarsharing.GetContext().Категории_Тех_Обслуживания.Count().ToString();
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
                    else if (cell.Column.Header.ToString() == "номер клиента")
                    {

                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexClient))
                        {
                            string toolTipText = dbCarsharing.GetContext().Клиенты.FirstOrDefault(c => c.ID_Клиента == indexClient).ФИО;
                            cell.ToolTip = toolTipText;
                        }
                    }
                    else if (cell.Column.Header.ToString() == "категория тех. обслуживания")
                    {

                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexCategory))
                        {
                            string toolTipText = dbCarsharing.GetContext().Категории_Тех_Обслуживания.FirstOrDefault(c => c.ID_Категории_Тех_Обслуживание == indexCategory).Наименование;
                            cell.ToolTip = toolTipText;
                        }
                    }

                }
            }
        }

        private void AddDTPButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDTP());
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTechnicalService());
        }

        private void AddСategoryButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCategoryTechinacalService());
        }

        private void SaveDTPButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    dtpDataGrid.ItemsSource = dbCarsharing.GetContext().ДТП.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpDataGrid.ItemsSource = dbCarsharing.GetContext().ДТП.ToArray();
            }
        }

        private void EditCarsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    dtpDataGrid.ItemsSource = dbCarsharing.GetContext().ДТП.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpDataGrid.ItemsSource = dbCarsharing.GetContext().ДТП.ToArray();
            }
        }

        private void DeleteDTPButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = dtpDataGrid.SelectedItems.Cast<ДТП>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().ДТП.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    dtpDataGrid.ItemsSource = dbCarsharing.GetContext().ДТП.ToArray();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void SaveServiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    serviceDataGrid.ItemsSource = dbCarsharing.GetContext().Техническое_Обслуживание.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                serviceDataGrid.ItemsSource = dbCarsharing.GetContext().Техническое_Обслуживание.ToArray();
            }
        }

        private void EditServiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    serviceDataGrid.ItemsSource = dbCarsharing.GetContext().Техническое_Обслуживание.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                serviceDataGrid.ItemsSource = dbCarsharing.GetContext().Техническое_Обслуживание.ToArray();
            }
        }

        

        private void SaveCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    categoryDataGrid.ItemsSource = dbCarsharing.GetContext().Категории_Тех_Обслуживания.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                categoryDataGrid.ItemsSource = dbCarsharing.GetContext().Категории_Тех_Обслуживания.ToArray();
            }
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    categoryDataGrid.ItemsSource = dbCarsharing.GetContext().Категории_Тех_Обслуживания.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                categoryDataGrid.ItemsSource = dbCarsharing.GetContext().Категории_Тех_Обслуживания.ToArray();
            }


        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = categoryDataGrid.SelectedItems.Cast<Категории_Тех_Обслуживания>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Категории_Тех_Обслуживания.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    categoryDataGrid.ItemsSource = dbCarsharing.GetContext().Категории_Тех_Обслуживания.ToArray();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void DeleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = serviceDataGrid.SelectedItems.Cast<Техническое_Обслуживание>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Техническое_Обслуживание.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    serviceDataGrid.ItemsSource = dbCarsharing.GetContext().Техническое_Обслуживание.ToArray();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
    }
}
