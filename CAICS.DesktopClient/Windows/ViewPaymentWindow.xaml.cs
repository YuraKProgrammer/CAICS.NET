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
using System.Windows.Shapes;

namespace CAICS.DesktopClient.Windows
{
    /// <summary>
    /// Interaction logic for ViewPaymentWindow.xaml
    /// </summary>
    public partial class ViewPaymentWindow : Window
    {
        private IPaymentsStorage PaymentsStorage = new TempPaymentsStorage();
        private Payment Payment;

        public ViewPaymentWindow(Payment payment)
        {
            InitializeComponent();
            Payment = payment;
            _name.Text = payment.Name;
            _value.Text = payment.Value.ToString();
            if (payment.Value > 0)
            {
                _value.Text = "+" + _value.Text;
                _value.Foreground = Brushes.Green;
            }
            if (payment.Value < 0)
            {
                _value.Foreground = Brushes.Red;
            }
        }

        public void _delete(object sender, RoutedEventArgs e)
        {
            PaymentsStorage.Remove(Payment);
            this.Close();
        }

        public void _cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
