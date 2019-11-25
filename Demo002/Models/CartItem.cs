﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo002.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}