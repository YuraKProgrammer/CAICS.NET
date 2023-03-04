using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAICS.Models
{
    public class Balance
    {
        public Currency Currency { get; set; }

        public int Value { get; set; }
        public Balance(Currency currency, int value)
        {
            Currency = currency;
            Value = value;
        }
    }
}
