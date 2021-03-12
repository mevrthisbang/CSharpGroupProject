﻿using System;
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
        public ActionResult Create(Bag bag)
        {
            TempData["CreateOrEdit"] = "Create";
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
            string extension = Path.GetExtension(bag.ImageFile.FileName);
            string filename = lastID + extension;
            bag.Image = "~/img/" + filename;
            filename = Path.Combine(Server.MapPath("~/img/"), filename);
            bag.ImageFile.SaveAs(filename);
            if (bagServiceClient.AddNewBag(bag))
            {

            }
            else
            {

            }
            return View("~/Views/Create.cshtml");
        }
        [HttpPost]
        public ActionResult Update(Bag bag)
        {
            TempData["CreateOrEdit"] = "Edit";
            return View();
        }
        public ActionResult Delete(string id)
        {
            return View();
        }
    }
}