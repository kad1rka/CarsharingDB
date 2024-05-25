using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public class PayemntsCars
    {
        public string авто { get; set; }
        public string доход { get; set; }
        // Остальные свойства
    }
    public class ClientsStatistic
    {
        public string клиент { get; set; }
        public string поездки { get; set; }
        public string доход { get; set; }
        // Остальные свойства
    }
    public partial class Reports : Page
    {
        public ObservableCollection<PayemntsCars> CarRevenue { get; set; }

        public ObservableCollection<ClientsStatistic> _clientStatistic { get; set; }
        public Reports()
        {
            InitializeComponent();
            TripsCount.Text = dbCarsharing.GetContext().Поездки.Count().ToString();
            string _sum = dbCarsharing.GetContext().Поездки.Sum(n => n.Стоимость).ToString();
            TripsSum.Text = $"на сумму {_sum.Remove(_sum.Length-5)} ₽";

            ClientCount.Text = dbCarsharing.GetContext().Клиенты.Count().ToString();
            var endTime = dbCarsharing.GetContext().Поездки.Select(n => n.ДатаВремя_Конца).ToArray();
            var startTime = dbCarsharing.GetContext().Поездки.Select(n => n.ДатаВремя_Начала).ToArray();
            TimeSpan[] differentHour = new TimeSpan[startTime.Length];
            int _sumHour = 0;
            for (int i = 0; i < endTime.Length; i++)
            {
                differentHour[i] = Convert.ToDateTime(endTime[i]).Subtract(Convert.ToDateTime(startTime[i]));
                _sumHour += (int)differentHour[i].Hours;
            }


            AvgHour.Text = (_sumHour / dbCarsharing.GetContext().Поездки.Count()).ToString();

            CarRevenue = new ObservableCollection<PayemntsCars>();
            var Cars = dbCarsharing.GetContext().Автомобили.Select(n => n.ID_Автомобиля).ToArray();
            foreach (var item in Cars)
            {
                string _car = dbCarsharing.GetContext().Автомобили.AsNoTracking().FirstOrDefault(n => n.ID_Автомобиля == item).Модель;
                string _money = dbCarsharing.GetContext().Поездки.AsNoTracking().Where(n => n.ID_Автомобиля == item).Sum(n => n.Стоимость).ToString();
                CarRevenue.Add(new PayemntsCars { авто = _car, доход = _money });
            }

            PayemntsCarsDataGrid.ItemsSource = CarRevenue;

            _clientStatistic = new ObservableCollection<ClientsStatistic>();
            var Clients = dbCarsharing.GetContext().Клиенты.Select(n => n.ID_Клиента).ToArray();
            foreach (var item in Clients)
            {
                string _client = dbCarsharing.GetContext().Клиенты.AsNoTracking().FirstOrDefault(n => n.ID_Клиента == item).ФИО;
                string _money = dbCarsharing.GetContext().Поездки.AsNoTracking().Where(n => n.ID_Клиента == item).Sum(n => n.Стоимость).ToString();
                string _count = dbCarsharing.GetContext().Поездки.AsNoTracking().Where(n => n.ID_Клиента == item).Sum(n => n.ID_Клиента).ToString();
                _clientStatistic.Add(new ClientsStatistic { клиент = _client, доход = _money , поездки = _count});
            }

            PayemntsClientsDataGrid.ItemsSource = _clientStatistic;

        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsKit.Text == "Доход/автомобиль")
            {
                PayemntsCarsDataGrid.Visibility = Visibility.Visible;
                PayemntsClientsDataGrid.Visibility = Visibility.Hidden;
            } else if (ReportsKit.Text == "Клиент/доход")
            {
                PayemntsCarsDataGrid.Visibility = Visibility.Hidden;
                PayemntsClientsDataGrid.Visibility = Visibility.Visible;
            }
        }
    }
}
