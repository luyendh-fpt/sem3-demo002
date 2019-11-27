using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo002.Models
{
    public class ShoppingCart
    {
        private Dictionary<int, CartItem> _cartItems = new Dictionary<int, CartItem>();
        public double _totalPrice = 0;

        public double GetTotalPrice()
        {
            this._totalPrice = 0;
            foreach (var item in _cartItems.Values)
            {
                this._totalPrice += item.UnitPrice * item.Quantity;
            }
            return this._totalPrice;
        }

        public List<CartItem> GetCartItems()
        {
            return _cartItems.Values.ToList();
        }

        public void AddCartItem(Product product, int quantity)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_cartItems.ContainsKey(product.Id))
            {
                var existItem = _cartItems[product.Id];
                // trong trường hợp tồn tại thì update số lượng và dừng xử lý.
                existItem.Quantity += quantity;
                if (existItem.Quantity <= 0)
                {
                    _cartItems.Remove(product.Id);
                }
                else
                {
                    _cartItems[product.Id] = existItem;
                }
                return;
            }
            // Trong trường hợp không tồn tại sản phẩm trong giỏ hàng thì thêm mới.
            _cartItems.Add(product.Id, new CartItem(product, quantity));
        }

        public void UpdateCartItem(Product product, int quantity)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_cartItems.ContainsKey(product.Id))
            {
                var existItem = _cartItems[product.Id];
                // trong trường hợp tồn tại thì update số lượng và dừng xử lý.
                existItem.Quantity = quantity;
                _cartItems[product.Id] = existItem;
                return;
            }
            // Trong trường hợp không tồn tại sản phẩm trong giỏ hàng thì thêm mới.
            _cartItems.Add(product.Id, new CartItem(product, quantity));
        }

        public void RemoveCartItem(int productId)
        {
            // Kiểm tra xem sản phẩm có tồn tại trong cart hay không?
            if (_cartItems.ContainsKey(productId))
            {
                _cartItems.Remove(productId);
                return;
            }
        }
    }
}