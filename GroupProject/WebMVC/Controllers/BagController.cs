using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagService;

namespace WebMVC.Controllers
{
    public class BagController : Controller
    {
        // GET: Bag
        WCFBagServiceClient bagServiceClient = new WCFBagServiceClient();
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Create()
        {
            TempData["CreateOrEdit"] = "Create";
            return View("~/Views/Create.cshtml");
        }

        public ViewResult Edit(string bagID)
        {
            TempData["CreateOrEdit"] = "Edit";
            Bag bag = bagServiceClient.GetBagByID(bagID);
            return View("~/Views/Edit.cshtml", bag);
        }
        [HttpPost]
        public ActionResult Create(Bag bag, HttpPostedFileBase ImageFile)
        {
            TempData["CreateOrEdit"] = "Create";
            if (ModelState.IsValid)
            {
                string lastID = bagServiceClient.GetLastBagID();
                if (lastID == null)
                {
                    lastID = "B_1";
                }
                else
                {
                    int count = int.Parse(lastID.Split('_')[1]) + 1;
                    lastID = "B_" + count;
                }
                string extension = Path.GetExtension(ImageFile.FileName);
                string filename = lastID + extension;
                bag.Image = "~/img/" + filename;
                filename = Path.Combine(Server.MapPath("~/img/"), filename);
                ImageFile.SaveAs(filename);
                bag.BagID = lastID;
                if (bagServiceClient.AddNewBag(bag))
                {

                }
                else
                {

                }
            }
            return View("~/Views/Create.cshtml", null);
        }
        [HttpPost]
        public ActionResult Update(Bag bag, HttpPostedFileBase ImageFile)
        {
            TempData["CreateOrEdit"] = "Edit";
            if (ModelState.IsValid)
            {
                
                string extension = Path.GetExtension(ImageFile.FileName);
                string filename = bag.BagID + extension;
                bag.Image = "~/img/" + filename;
                filename = Path.Combine(Server.MapPath("~/img/"), filename);
                ImageFile.SaveAs(filename);
                if (bagServiceClient.UpdateBag(bag))
                {

                }
                else
                {

                }
            }
            return View("~/Views/Update.cshtml", bag);
        }
        [HttpGet]
        public ActionResult Delete(string bagID)
        {
            if (bagServiceClient.DeleteBag(bagID))
            {

            }
            else
            {

            }
            return RedirectToAction("Index", "Home");
        }
    }
}