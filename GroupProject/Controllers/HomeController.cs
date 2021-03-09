using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class HomeController : Controller
    {
        string strConnection = "server=SE140157;database=BagStore;uid=sa;pwd=123456";
        //SqlConnection con = new SqlConnection();
        //SqlCommand cmd = new SqlCommand();
        //SqlDataReader reader;

        private static BagData bd = new BagData();
        private static List<BagDTO> list = new List<BagDTO>();

        public static List<BagDTO> BagList
        {
            get
            {
                return list;
            }
        }

        [HttpPost]
        public ViewResult SearchbyName(FormCollection search)
        {

            string searchValue = search["txtSearch"];
            BagData dao = new BagData();
            List<BagDTO> result = dao.searchBag(searchValue);

            return View();
        }
        //public ActionResult getList()
        //{
        //    var list = new List<BagDTO>();
        //    list = bd.GetBagList();
        //    return View(list);
           
        //}
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var list = new List<BagDTO>();
            list = bd.GetBagList();
            return View(list);
        }


    }
}
