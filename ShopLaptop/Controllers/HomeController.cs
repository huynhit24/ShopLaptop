using PagedList;
using ShopLaptop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopLaptop.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            HomeModel home = new HomeModel();
            return View(home);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            var laptop = data.Laptops.Where(n => n.malaptop == id).FirstOrDefault();
            return View(laptop);
        }

        public ActionResult ListLaptopTheoHangId(int? page, int id)
        {
            if (page == null) page = 1;
            var all_laptop = (from s in data.Laptops select s).OrderBy(m => m.malaptop).Where(n => n.mahang == id && n.trangthai == true);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_laptop.ToPagedList(pageNum, pageSize));
        }

        public ActionResult ListLaptopTheoNhuCauById()
        {
            return View();
        }
    }
}