﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo002.Models;

namespace Demo002.Service
{
    public class OrderService: IOrderService
    {
        private Demo002Context db = new Demo002Context();
        public bool createOrder(ShoppingCart cart, CartInformation cartInformation)
        {
            if (cart.GetCartItems().Count == 0)
            {
                return false;
            }
            var order = new Order();
            order.MemberId = 1;
            order.PaymentTypeId = cartInformation.PaymentTypeId;
            order.ShipName = cartInformation.ShipName;
            order.ShipPhone = cartInformation.ShipPhone;
            order.ShipAddress = cartInformation.ShipAddress;
            order.TotalPrice = cart.GetTotalPrice();
            var orderDetails = new List<OrderDetail>();
            bool existError = false;
            foreach (var item in cart.GetCartItems())
            {
                Product product = db.Products.Find(item.ProductId);
                if (product == null)
                {
                    existError = true;
                    break;
                }
                var orderDetail = new OrderDetail();
                orderDetail.ProductId = product.Id;
                orderDetail.OrderId = order.Id;
                orderDetail.Quantity = item.Quantity;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetails.Add(orderDetail);
            }
            if (!existError)
            {
                order.OrderDetails = orderDetails;
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}