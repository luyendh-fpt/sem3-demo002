using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo002.Models;
using Demo002.Service;

namespace Demo002.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Demo002Context db = new Demo002Context();

        private IOrderService orderService = new OrderService();

        public static string ShoppingCartAttribute = "ShoppingCart";

        // GET: ShoppingCart
        public ActionResult Index()
        {
            ViewBag.ShoppingCart = LoadShoppingCart();
            return View();
        }

        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }

            var shoppingCart = LoadShoppingCart();
            shoppingCart.AddCartItem(product, quantity);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid quantity.'");
            }
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }
            var shoppingCart = LoadShoppingCart();
            shoppingCart.UpdateCartItem(product, quantity);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's not found.'");
            }
            var shoppingCart = LoadShoppingCart();
            shoppingCart.RemoveCartItem(productId);
            SaveShoppingCart(shoppingCart);
            return Redirect("/ShoppingCart");
        }

        public ActionResult CreateOrder()
        {
            var shoppingCart = LoadShoppingCart();
            if (orderService.createOrder(shoppingCart))
            {
                TempData["msg"] = "Order success!";
                ClearCart();
            }
            return Redirect("/Products");
        }

        private void ClearCart()
        {
            Session.Remove(ShoppingCartAttribute);
        }

        /**
         * Lưu thông tin cart vào session.
         */
        private void SaveShoppingCart(ShoppingCart cart)
        {
            Session[ShoppingCartAttribute] = cart;
        }

        /**
         * Kiểm tra sự tồn tại của shopping cart trong session.
         * Nếu chưa có thì trả về một shopping cart mới.
         */
        private ShoppingCart LoadShoppingCart()
        {
            if (Session[ShoppingCartAttribute] is ShoppingCart currentShoppingCart)
            {
                return currentShoppingCart;
            }
            return new ShoppingCart();
        }
    }
}