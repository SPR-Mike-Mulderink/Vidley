﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
    }
}