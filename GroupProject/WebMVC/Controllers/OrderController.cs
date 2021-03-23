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
            bool check = false;
            foreach(Bag bag in cart.cart.Values)
            {
                if (bag.Quantity > bagServiceClient.CheckQuantity(bag.BagID))
                {
                    ModelState.AddModelError("Quantity" + bag.BagID, "Quantity in stock: " + bagServiceClient.CheckQuantity(bag.BagID));
                    check = true;
                }
            }
            if (!check)
            {
                string lastID = bagServiceClient.GetLastOrderID(Username);

                if (lastID == null)
                {
                    lastID = "OD_" + Username + "_1";
                }
                else
                {
                    int count = int.Parse(lastID.Split('_')[2])+1;
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
            return View("~/Views/Cart.cshtml", cart);
        }
        [CustomAuthorize(Roles ="customer")]
        public ActionResult GetOrderHistory(string status)
        {
            string Username = SessionPersister.Username;
            WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
            Order[] listOrders = bagServiceClient.GetOrderHistoryByUser(Username);
            
            if (listOrders != null)
            {
                switch (status)
                {
                    case "Verifying":
                        listOrders = listOrders.Where(order => order.status.Equals("Verifying")).ToArray();
                    break;
                    case "Completed":
                        listOrders = listOrders.Where(order => order.status.Equals("Completed")).ToArray();
                        break;
                    case "Processing":
                        listOrders = listOrders.Where(order => order.status.Equals("Processing")).ToArray();
                        break;
                }
                foreach (Order order in listOrders)
                {
                    order.ListBuyBags = bagServiceClient.GetOrderByOrderID(order.OrderID).ListBuyBags;
                }
            }
            return View("~/Views/OrderHistory.cshtml", listOrders);
        }
    }
}