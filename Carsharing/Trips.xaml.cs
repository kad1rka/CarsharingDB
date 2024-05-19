using System;
using System.Collections.Generic;
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

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для Trips.xaml
    /// </summary>
    public partial class Trips : Page
    {
        public Trips()
        {
            InitializeComponent();
            tripsDataGrid.ItemsSource = dbCarsharing.GetContext().Поездки.ToArray();
            countTripRows.Text = dbCarsharing.GetContext().Поездки.Count().ToString();
        }
        private void DeleteTripButton_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = tripsDataGrid.SelectedItems.Cast<Поездки>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {usersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbCarsharing.GetContext().Поездки.RemoveRange(usersForRemoving);
                    dbCarsharing.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Удаление данных", MessageBoxButton.OK);
                    tripsDataGrid.ItemsSource = dbCarsharing.GetContext().Автомобили.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
        private void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null)

            {
                if (cell.Column.Header != null)
                {
                    if (cell.Column.Header.ToString() == "авто")
                    {

                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexCar))
                        {
 
                            using (var db = new dbCarsharing())
                            {

                                    var SearchObject = db.Автомобили
                                        .AsNoTracking().
                                        FirstOrDefault(c => c.ID_Автомобиля == indexCar);
                                    if (SearchObject != null)
                                    {
                                        cell.ToolTip = $"{SearchObject.Модель}";
                                    }
                                    else
                                    {
                                        cell.ToolTip= "Автомобиль не найден";
                                    }
                            }
                        }         
                    } 
                    else if (cell.Column.Header.ToString() == "клиент")
                    {
                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexClient))
                        {
                            using (var db = new dbCarsharing())
                            {

                                var SearchObject = db.Клиенты
                                    .AsNoTracking().
                                    FirstOrDefault(c => c.ID_Клиента == indexClient);
                                if (SearchObject != null)
                                {
                                    cell.ToolTip = $"{SearchObject.ФИО}";
                                }
                                else
                                {
                                    cell.ToolTip = "Автомобиль не найден";
                                }
                            }
                        }
                    }
                    else if (cell.Column.Header.ToString() == "локация начала")
                    {
                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexLocation))
                        {
                            using (var db = new dbCarsharing())
                            {

                                var SearchObject = db.Локации_Парковочных_Мест
                                    .AsNoTracking().
                                    FirstOrDefault(c => c.ID_Локации == indexLocation);
                                if (SearchObject != null)
                                {
                                    cell.ToolTip = $"{SearchObject.Описание}";
                                }
                                else
                                {
                                    cell.ToolTip = "Локация не найдена";
                                }
                            }
                        }
                    }
                    else if (cell.Column.Header.ToString() == "локация конца")
                    {
                        if (int.TryParse((cell.Content as TextBlock)?.Text, out int indexLocation))
                        {
                            using (var db = new dbCarsharing())
                            {

                                var SearchObject = db.Локации_Парковочных_Мест
                                    .AsNoTracking().
                                    FirstOrDefault(c => c.ID_Локации == indexLocation);
                                if (SearchObject != null)
                                {
                                    cell.ToolTip = $"{SearchObject.Описание}";
                                }
                                else
                                {
                                    cell.ToolTip = "Локация не найдена";
                                }
                            }
                        }
                    }

                }
            }

        }
        private void EditTripButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно обновлены", "Обновление данных", MessageBoxButton.OK);
                    tripsDataGrid.ItemsSource = dbCarsharing.GetContext().Поездки.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                tripsDataGrid.ItemsSource = dbCarsharing.GetContext().Поездки.ToList();
            }

        }

        private void SaveTripButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var dbContext = new dbCarsharing())
                {

                    dbContext.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Обновление данных", MessageBoxButton.OK);
                    tripsDataGrid.ItemsSource = dbCarsharing.GetContext().Поездки.ToArray();
                    dbCarsharing.GetContext().SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                tripsDataGrid.ItemsSource = dbCarsharing.GetContext().Поездки.ToList();
            }
        }

        private void AddTripButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTrip());
        }
    }
}
