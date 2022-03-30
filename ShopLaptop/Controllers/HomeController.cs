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

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection collection, LienHe lh)
        {
            var hoten = collection["hoten"];
            var email = collection["email"];
            var dienthoai = collection["dienthoai"];
            var website = collection["website"];
            var noidung = collection["noidung"];
            /*var trangthai = collection["trangthai"];*/

            lh.hoten = hoten;
            lh.email = email;
            lh.dienthoai = dienthoai;
            lh.website = website;
            lh.noidung = noidung;
            lh.trangthai = true;
            
            data.LienHes.InsertOnSubmit(lh);
            data.SubmitChanges();
            return RedirectToAction("Index");
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

        public ActionResult ListLaptopTheoNhuCauById(int? page, int id)
        {
            if (page == null) page = 1;
            var all_laptop = (from s in data.Laptops select s).OrderBy(m => m.malaptop).Where(n => n.manhucau == id && n.trangthai == true);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_laptop.ToPagedList(pageNum, pageSize));
        }
    }
}