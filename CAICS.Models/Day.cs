using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAICS.Models
{
    public class Day
    {
        private List<Payment> Payments { get; set; }

        public Day(List<Payment> payments)
        {
            Payments = payments;
        }

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }

        public void DaletePayment(Payment payment)
        {

        }
    }
}
