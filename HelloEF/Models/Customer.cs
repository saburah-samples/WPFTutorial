﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEF.Models
{
    public class Customer
    {
        public int CustomerID
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }
    }
}
