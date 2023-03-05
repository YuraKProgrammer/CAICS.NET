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
    /// Interaction logic for AddPaymentWindow.xaml
    /// </summary>
    public partial class AddPaymentWindow : Window
    {
        private IPaymentsStorage PaymentsStorage = new TempPaymentsStorage();
        private DateTime Date = new DateTime();

        public AddPaymentWindow(DateTime dateTime)
        {
            InitializeComponent();
            Date = dateTime;
        }

        public void _add(object sender, RoutedEventArgs e)
        {
            PaymentsStorage.Save(new Payment(Int32.Parse(_value.Text), _name.Text, Date));
            this.Close();
        }

        public void _cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
