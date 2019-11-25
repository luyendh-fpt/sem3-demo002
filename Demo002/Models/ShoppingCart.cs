using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo002.Models
{
    public class ShoppingCart
    {
        private List<CartItem> _cartItems;
        public double TotalPrice { get; set; }

        public List<CartItem> GetCartItems()
        {
            if (_cartItems == null)
            {
                _cartItems = new List<CartItem>();
            }
            return _cartItems;
        }

        public void SetCartItems(List<CartItem> items)
        {
            _cartItems = items;
        }

        public void AddCartItem(CartItem item)
        {
            if (_cartItems == null)
            {
                _cartItems = new List<CartItem>();
            }
            _cartItems.Add(item);
        }


    }
}