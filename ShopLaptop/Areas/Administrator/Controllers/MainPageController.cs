using Newtonsoft.Json;
using ShopLaptop.Common;
using ShopLaptop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopLaptop.Areas.Administrator.Controllers
{
    public class MainPageController : Controller
    {
        // GET: Administrator/MainPage
        DataModel db = new DataModel();
        // GET: Admin/adm_MainPage
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "MainPage");
            }
            else
            {
                return View();
            }            
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {

            var taikhoan = collection["account"];
            var matkhau = collection["password"];
            var hashpass = CommonFields.getStringSHA256Hash(matkhau).Substring(0,32);
            if (String.IsNullOrEmpty(taikhoan))
            {
                if (String.IsNullOrEmpty(matkhau))
                {
                    ViewBag.ThongBao = "Thông tin đăng nhập đang trống";
                }
                else
                    ViewBag.ThongBao = "Vui lòng điền Account";
            }
            else
            {
                if (String.IsNullOrEmpty(matkhau))
                {
                    ViewBag.ThongBao = "Vui lòng điền Password";
                }
                else
                {
                    Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == taikhoan && n.PassAdmin == hashpass);
                    if (ad != null)
                    {
                        Session["taikhoanadmin"] = ad;
                        return RedirectToAction("Index", "MainPage");
                    }
                    else
                        ViewBag.ThongBao = "Thông tin đăng nhập không đúng";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["taikhoanadmin"] = null;
            return RedirectToAction("Login", "MainPage");
        }
    }
}