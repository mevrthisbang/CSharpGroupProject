using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BagService;
using WebMVC.FileService;
using WebMVC.Security;

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
        [CustomAuthorize(Roles = "admin")]
        public ViewResult Create()
        {
            TempData["CreateOrEdit"] = "Create";
            return View("~/Views/Create.cshtml");
        }
        [CustomAuthorize(Roles = "admin")]
        public ViewResult Edit(string bagID)
        {
            TempData["CreateOrEdit"] = "Edit";
            Bag bag = bagServiceClient.GetBagByID(bagID);
            return View("~/Views/Edit.cshtml", bag);
        }
        [HttpPost]
        [CustomAuthorize(Roles = "admin")]
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
                string filename = lastID + "_" + DateTime.Now.ToString("yyyyMMdd") + extension;
                bag.Image = "http://localhost:55575/img/" + filename;
                WCFFileServiceClient fileServiceClient = new WCFFileServiceClient();
                fileServiceClient.UploadFile(filename,ImageFile.InputStream);
                bag.BagID = lastID;

                if (bagServiceClient.AddNewBag(bag))
                {
                    TempData["SuccessMessage"] = "Add Bag Successfully";
                    ModelState.Clear();
                }
                else
                {
                    TempData["FailMessage"] = "Add Bag Failed";
                }
            }
            return View("~/Views/Create.cshtml");
        }
        [HttpPost]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Update(Bag bag, HttpPostedFileBase ImageFile)
        {
            TempData["CreateOrEdit"] = "Edit";
            if (ModelState.IsValid)
            {
                
                string extension = Path.GetExtension(ImageFile.FileName);
                string filename = bag.BagID +"_"+DateTime.Now.ToString("yyyyMMdd")+ extension;
                bag.Image = "http://localhost:55575/img/" + filename;
                WCFFileServiceClient fileServiceClient = new WCFFileServiceClient();
                fileServiceClient.UploadFile(filename, ImageFile.InputStream);
                if (bagServiceClient.UpdateBag(bag))
                {
                    TempData["SuccessMessage"] = "Update Bag Successfully";
                }
                else
                {
                    TempData["FailMessage"] = "Update Bag Failed";
                }
            }
            return Edit(bag.BagID);
        }
        [HttpGet]
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(string bagID)
        {
            if (bagServiceClient.DeleteBag(bagID))
            {
                TempData["SuccessMessage"] = "Deleted Successfully";
            }
            else
            {
                TempData["FailMessage"] = "Deleted Failed";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}