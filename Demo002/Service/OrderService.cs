using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo002.Models;

namespace Demo002.Service
{
    public class OrderService: IOrderService
    {
        private Demo002Context db = new Demo002Context();
        public bool createOrder(ShoppingCart cart)
        {
            // chuyển sang order, với từng cart item chuyển thành một order detail tương ứng và
            // save tất cả trong một transaction: begin traction, commit, rollback
            throw new NotImplementedException();
        }
    }
}