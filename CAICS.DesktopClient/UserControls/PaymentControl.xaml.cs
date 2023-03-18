using CAICS.Models;
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

namespace CAICS.DesktopClient.UserControls
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        private Payment _payment;
        public Payment Payment
        {
            get
            {
                return _payment;
            }
            set
            {
                _payment = value;
                Name.Text = _payment.Name + "   ";
                Value.Text = _payment.Value.ToString();
                if (_payment.Value > 0)
                {
                    Value.Text = "+" + Value.Text;
                    Value.Foreground = Brushes.Green;
                }
                if (_payment.Value < 0)
                {
                    Value.Foreground = Brushes.Red;
                }
            }
        }
        private void PaymentControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Payment = DataContext as Payment;
        }

        public PaymentControl(Payment payment) : this()
        {
            InitializeComponent();
            _payment = payment;
            Name.Text = payment.Name + " ";
            Value.Text = payment.Value.ToString();
            if (payment.Value > 0)
            {
                Value.Foreground = Brushes.Green;
            }
            if (payment.Value < 0)
            {
                Value.Foreground = Brushes.Red;
            }
        }

        public PaymentControl()
        {
            InitializeComponent();
            DataContextChanged += PaymentControl_DataContextChanged;
        }
    }
}
