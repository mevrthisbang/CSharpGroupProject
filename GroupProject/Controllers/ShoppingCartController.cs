using GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult Index()
        {
            //var cart = Session["CART"];
            //var list = new List<CartDTO>();
            //if (cart != null)
            //{
            //    list = (List<CartDTO>)cart;
            //}
            CartObj cart = (CartObj)Session["CART"];
            var Cart = new CartObj();
            if(cart!=null)
            {
                Cart = cart;
            }
            return View(Cart);
        }
        public ActionResult addToCart()
        {
            string username = "haohao";
            CartObj cart = (CartObj)Session["CART"];

            string id = "B1";
            string name = "Hermes";
            string image = "https://cdn-images.farfetch-contents.com/16/38/93/68/16389368_31702749_1000.jpg";
            string description = "lalal";
            string cateID = "1";
            DateTime dateTime = new DateTime();
            double price = 18623.00;
            int quantity = 100;
            int quantityCart = 1;
            if(cart==null)
            {
                cart = new CartObj(username);
            }

            CartDTO cartDTO = new CartDTO
            {
                id = id,
                name = name,
                image = image,
                description=description,
                category=cateID,
                date=dateTime,
                price=price,
                quantity=quantity,
                quantityCart=quantityCart

            };
            cart.addToCart(cartDTO);
            Session["CART"] = cart;
            Session["USERNAME"] = username;
           
            return RedirectToAction("Index");
        }
        public ActionResult updateAddCart(string bid, int quantity)
        {
            CartObj cart = (CartObj)Session["CART"];
            quantity += 1;
            cart.updateCart(bid, quantity);
            Session["CART"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult updateSubCart(string bid, int quantity)
        {
            CartObj cart = (CartObj)Session["CART"];
            if (quantity<=1)
            {

            }
            else
            {
                quantity -= 1;
            }
            cart.updateCart(bid, quantity);
            Session["CART"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult removeCart(string id)
        {
            //var list = (List<CartDTO>)Session["CART"];
            //list.RemoveAll(x => x.bag.id == id);

            //Session["CART"] = list;
            return RedirectToAction("Index");
        }
    }
}