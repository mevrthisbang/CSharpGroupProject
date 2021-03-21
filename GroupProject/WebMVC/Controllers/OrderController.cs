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
    public class OrderController : Controller
    {
        // GET: Order
        [CustomAuthorize(Roles="customer")]
        [HttpPost]
        public ActionResult Order()
        {
            string Username = SessionPersister.Username;
            Cart cart = (Cart)Session["CART"];
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            string lastID = bagServiceClient.GetLastOrderID(Username);
            if (lastID == null)
            {
                lastID = "OD_" + Username + "_1";
            }
            else
            {
                int count = int.Parse(lastID.Split('_')[2]);
                lastID = "OD_" + Username + "_" + count;
            }
            Order order = new Order
            {
                OrderID = lastID,
                Customer = Username,
                ListBuyBags = cart.cart,
                Total = cart.Total
            };
            if (bagServiceClient.Checkout(order))
            {
                TempData["SuccessMessage"] = "Checkout Successfully. Check order in Order History";
                Session.Remove("CART");
            }
            else
            {
                TempData["FailMessage"] = "Checkout Fail";
            }
            
            return RedirectToAction("Customer", "Home");
        }
    }
}