using CAICS.DesktopClient.Windows;
using CAICS.Models;
using CAICS.PaymentsStorage;
using System;
using System.Collections.Generic;
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

namespace CAICS.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime Date = DateTime.UtcNow;
        public Balance Balance = new Balance(Currency.Rubles, 0);
        public List<Payment> payments = new List<Payment>();
        public IPaymentsStorage paymentsStorage = new TempPaymentsStorage();
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }


        public void Update()
        {
            var sum = 0;
            var sum2 = 0;
            payments = paymentsStorage.LoadAll();
            var dayPayments = payments.Where(p => p.DateTime <= Date);
            foreach (var p in dayPayments)
            {
                if (p.Value > 0)
                {
                    sum += p.Value;
                    sum2 += p.Value;
                }
                else
                {
                    sum2 += p.Value;
                }
            }
            _balanceProgress.Maximum = sum;
            _balanceProgress.Minimum = 0;
            if (sum2 <= 0)
            {
                _balanceProgress.Value = 0;
            }
            else
            {
                _balanceProgress.Value = sum2;
            }
            Balance.Value = sum2; 
            if (Balance == null)
            {
                Balance = new Balance(Currency.Rubles,0);
            }
            _balanceText.Text = "В кошельке: " + Balance.Value + " рублей";
            _dateTime.Text = Date.AddHours(3).ToString();
            lb.ItemsSource = payments.Where(p => p.DateTime.Day == Date.Day && p.DateTime.Month == Date.Month && p.DateTime.Year == Date.Year);
        }

        public void _payments_reload(object sender, RoutedEventArgs e)
        {
            Update();
        }

        public void _addPayment(object sender, RoutedEventArgs e)
        {
            Window window = new AddPaymentWindow(Date);
            window.Show();
        }

        public void _addRegularPayment(object sender, RoutedEventArgs e)
        {
            if (lb.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите уже существующую оплату!", "Сообщение");
            }
            else
            {
                var p = (Payment)lb.SelectedItem;
                var d1 = Date.AddYears(1);
                for (DateTime d = Date.AddMonths(1); DateTime.Compare(d, d1) <= 0; d=d.AddMonths(1))
                {
                    paymentsStorage.Save(new Payment(p.Value, p.Name, d));
                }
            }
        }

        public void _nextDay(object sender, RoutedEventArgs e)
        {
            Date = Date.AddDays(1);
            Update();
        }

        public void _next3Day(object sender, RoutedEventArgs e)
        {
            Date = Date.AddDays(3);
            Update();
        }

        public void _nextWeek(object sender, RoutedEventArgs e)
        {
            Date = Date.AddDays(7);
            Update();
        }

        public void _nextMonth(object sender, RoutedEventArgs e)
        {
            Date = Date.AddMonths(1);
            Update();
        }

        public void _previousDay(object sender, RoutedEventArgs e)
        {
            Date = Date.AddDays(-1);
            Update();
        }
        
        public void _previous3Day(object sender, RoutedEventArgs e)
        {
            Date = Date.AddDays(-3);
            Update();
        }

        public void _previousWeek(object sender, RoutedEventArgs e)
        {
            Date = Date.AddDays(-7);
            Update();
        }

        public void _previousMonth(object sender, RoutedEventArgs e)
        {
            Date = Date.AddMonths(-1);
            Update();
        }

        public void _lb_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            var window = new ViewPaymentWindow((Payment)lb.SelectedItem);
            window.Show();
        }
    }
}
