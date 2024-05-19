using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
            tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();
            clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();
            paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();
            countClientsRows.Text = dbCarsharing.GetContext().Клиенты.Count().ToString();
            countTariffRows.Text = dbCarsharing.GetContext().Тарифы.Count().ToString();
            countPaymentsRows.Text = dbCarsharing.GetContext().Оплата.Count().ToString();
        }

        private void AddClientsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClients());
        }

        private void AddTariffButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTariff());
        }

        private void AddInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPayments());
        }
        private void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null)

            {
                if (cell.Column.Header != null)
                {
                    if (cell.Column.Header.ToString() == "номер поездки")
                    {

                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexTrip))
                        {

                            using (var db = new dbCarsharing())
                            {

                                var SearchObject = db.Поездки
                                    .AsNoTracking().
                                    FirstOrDefault(c => c.ID_Поездки == indexTrip);
                                if (SearchObject != null)
                                {
                                    var car = db.Автомобили.AsNoTracking().FirstOrDefault(n => n.ID_Автомобиля == SearchObject.ID_Автомобиля);
                                    cell.ToolTip = $"{SearchObject.ДатаВремя_Конца} {car.Модель}";
                                }
                                else
                                {
                                    cell.ToolTip = "Поездка не найдена";
                                }
                            }
                        }
                    }

                }
            }

        }

        private void SaveClientsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();
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
                    clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();
            }
        }

        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = clientsDataGrid.SelectedItems.Cast<Клиенты>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Клиенты.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    clientsDataGrid.ItemsSource = dbCarsharing.GetContext().Клиенты.ToArray();

                }
            }
        }

        private void SaveTariffButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();
            }
        }

        private void EditTariffButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();
            }
        }

        private void DeleteTariffButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = tariffDataGrid.SelectedItems.Cast<Тарифы>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Тарифы.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tariffDataGrid.ItemsSource = dbCarsharing.GetContext().Тарифы.ToArray();

                }
            }
        }

        private void SavePaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();
            }
        }

        private void EditInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();
            }
        }

        private void DeleteInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = paymentsDataGrid.SelectedItems.Cast<Оплата>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {ForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Оплата.RemoveRange(ForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    paymentsDataGrid.ItemsSource = dbCarsharing.GetContext().Оплата.ToArray();

                }
            }
        }
    }
}
