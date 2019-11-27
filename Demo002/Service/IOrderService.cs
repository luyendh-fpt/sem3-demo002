using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo002.Models;

namespace Demo002.Service
{
    interface IOrderService
    {
        bool createOrder(ShoppingCart cart);
    }
}
