using Mvc.DAC;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index(string returnUrl)
        {
            //세션에서 장바구니정보를 조회해서 목록으로 보여준다.
            //ViewBag.ReturnUrl = returnUrl;
            CartIndexViewModel cartModel = new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };
            return View(cartModel);
        }

        public ActionResult AddToCart(int productID, string returnUrl)
        {
            //선택된 제품을 세션에 추가
            ProductDAC dac = new ProductDAC();
            Product prod = dac.GetProductInfo(productID);
            Cart cart = GetCart();
            cart.AddItem(prod, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult RemoveFromCart(int ProductID, string returnUrl)
        {
            GetCart().RemoveItem(ProductID);
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}