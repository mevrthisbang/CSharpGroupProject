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
            var cart = Session["CART"];
            var list = new List<CartDTO>();
            if (cart != null)
            {
                list = (List<CartDTO>)cart;
            }
            return View(list);
        }
        public ActionResult addToCart(string id = "B2", int quantityCart = 1)
        {
            var cart = Session["CART"];
            var bag = BagDAO.getBagbyID(id);
            if (cart != null)
            {
                var list = (List<CartDTO>)cart;
                if (list.Exists(x => x.bag.id == id))
                {
                    foreach (var item in list)
                    {
                        if (item.bag.id == id)
                        {
                            item.quantity += quantityCart;
                        }
                    }
                }
                //else
                //{
                //    var dto = new CartDTO();
                //    dto.bag = bag;
                //    dto.quantity = quantityCart;
                //    list.Add(dto);
                //}
                Session["CART"] = list;
            }
            else
            {
                var list = new List<CartDTO>();
                if (bag != null) {
                    var dto = new CartDTO();
                    dto.bag = bag;
                    dto.quantity = quantityCart;

                    list.Add(dto);
                }
                Session["CART"] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult updateAddCart(string bid)
        {
            var cart = Session["CART"];
            var list = (List<CartDTO>)cart;
            foreach (var item in list)
            {
                if (item.bag.id == bid)
                {
                    item.quantity += 1;
                }
            }
            Session["CART"] = list;
            return RedirectToAction("Index");
        }
        public ActionResult updateSubCart(string bid, int quantity)
        {
            var cart = Session["CART"];
            var list = (List<CartDTO>)cart;
            if (quantity <= 1) { list.RemoveAll(x => x.bag.id == bid); }
            else
            {
                foreach (var item in list)
                {
                    if (item.bag.id == bid)
                    {
                        item.quantity -= 1;
                    }
                }
            }
            Session["CART"] = list;
            return RedirectToAction("Index");
        }
        public ActionResult removeCart(string id)
        {
            var list = (List<CartDTO>)Session["CART"];
            list.RemoveAll(x => x.bag.id == id);

            Session["CART"] = list;
            return RedirectToAction("Index");
        }
    }
}