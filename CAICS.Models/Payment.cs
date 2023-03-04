﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAICS.Models
{
    public class Payment
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public Payment(int value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}