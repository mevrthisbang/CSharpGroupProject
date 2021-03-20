using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagService;
using WebMVC.Models;
using WebMVC.Security;

namespace WebMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["CART"];
            return View("~/Views/Cart.cshtml", cart);
        }
        [CustomAuthorize(Roles ="customer")]
        [HttpPost]
        public ActionResult AddToCart(string ID)
        {
            string username = SessionPersister.Username;
            Cart cart = (Cart)Session["CART"];
            if (cart == null||(cart!=null&&!cart.username.Equals(username)))
            {
                cart = new Cart(username);
            }
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            Bag bag = bagServiceClient.GetBagByID(ID);
            cart.addToCart(bag);
            Session["CART"] = cart;
            TempData["SuccessMessage"] = "Add to Cart Successfully";
            return RedirectToAction("Customer", "Home");
        }
        [CustomAuthorize(Roles = "customer")]
        public ActionResult UpdateAddCart(string bid)
        {
            Cart cart = (Cart)Session["CART"];
            Bag bag = cart.cart[bid];
            bag.Quantity += 1;
            cart.updateCart(bag);
            Session["CART"] = cart;
            return RedirectToAction("Index", "Cart");
        }
        [CustomAuthorize(Roles = "customer")]
        public ActionResult UpdateSubCart(string bid)
        {
            Cart cart = (Cart)Session["CART"];
            Bag bag = cart.cart[bid];
            bag.Quantity -= 1;
            if (bag.Quantity <= 0)
            {
                cart.removeCart(bid);
            }
            else
            {
                cart.updateCart(bag);
            }
            Session["CART"] = cart;
            return RedirectToAction("Index");
        }
        [CustomAuthorize(Roles = "customer")]
        public ActionResult RemoveCart(string id)
        {
            Cart cart = (Cart)Session["CART"];
            cart.removeCart(id);
            //var list = (List<CartDTO>)Session["CART"];
            //list.RemoveAll(x => x.bag.id == id);
            Session["CART"] = cart;
            return RedirectToAction("Index", "Cart");
        }
    }
}