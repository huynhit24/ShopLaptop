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

            List<DataPoint> dataPoints = new List<DataPoint>();
            var listLaptop = db.Laptops.ToList();
            var listHang = db.Hangs.ToList();
            foreach (var item in listHang)
            {
                var countLaptop = listLaptop.Count(p => p.mahang == item.mahang);
                dataPoints.Add(new DataPoint(item.tenhang, countLaptop));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            /*List<PaymentState> listPaymentState = new List<PaymentState>();
            PaymentState ps = new PaymentState();
            PaymentState ps1 = new PaymentState();
            PaymentState ps2 = new PaymentState();
            PaymentState ps3 = new PaymentState();
            PaymentState ps4 = new PaymentState();
            ps.state = 0; ps.name_state = "Cancelled";
            listPaymentState.Add(ps);
            ps1.state = 1; ps1.name_state = "On hold";
            listPaymentState.Add(ps1);
            ps2.state = 2; ps2.name_state = "Being prepared";
            listPaymentState.Add(ps2);
            ps3.state = 3; ps3.name_state = "On way";
            listPaymentState.Add(ps3);
            ps4.state = 4; ps4.name_state = "Received";
            listPaymentState.Add(ps4);
            var listPayment = db.Payments.ToList();
            foreach (var item in listPaymentState)
            {
                var countPayment = listPayment.Count(p => p.state == item.state);
                dataPoints1.Add(new DataPoint(item.name_state, countPayment));
            }*/
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            List<DataPoint1> dataPoints2 = new List<DataPoint1>();

            dataPoints2.Add(new DataPoint1(1496255400000, 2500));
            dataPoints2.Add(new DataPoint1(1496341800000, 2790));
            dataPoints2.Add(new DataPoint1(1496428200000, 3380));
            dataPoints2.Add(new DataPoint1(1496514600000, 4940));
            dataPoints2.Add(new DataPoint1(1496601000000, 4020));
            dataPoints2.Add(new DataPoint1(1496687400000, 3390));
            dataPoints2.Add(new DataPoint1(1496773800000, 4200));
            dataPoints2.Add(new DataPoint1(1496860200000, 3150));
            dataPoints2.Add(new DataPoint1(1496946600000, 3230));
            dataPoints2.Add(new DataPoint1(1497033000000, 4200));
            dataPoints2.Add(new DataPoint1(1497119400000, 5210));
            dataPoints2.Add(new DataPoint1(1497205800000, 4940));
            dataPoints2.Add(new DataPoint1(1497292200000, 3500));
            dataPoints2.Add(new DataPoint1(1497378600000, 3790));
            dataPoints2.Add(new DataPoint1(1497465000000, 3230));
            dataPoints2.Add(new DataPoint1(1497551400000, 2900));
            dataPoints2.Add(new DataPoint1(1497637800000, 3080));
            dataPoints2.Add(new DataPoint1(1497724200000, 3370));
            dataPoints2.Add(new DataPoint1(1497810600000, 2880));
            dataPoints2.Add(new DataPoint1(1497897000000, 3170));
            dataPoints2.Add(new DataPoint1(1497983400000, 3280));
            dataPoints2.Add(new DataPoint1(1498069800000, 4070));
            dataPoints2.Add(new DataPoint1(1498156200000, 5280));
            dataPoints2.Add(new DataPoint1(1498242600000, 4970));
            dataPoints2.Add(new DataPoint1(1498329000000, 2560));
            dataPoints2.Add(new DataPoint1(1498415400000, 2790));
            dataPoints2.Add(new DataPoint1(1498501800000, 3800));
            dataPoints2.Add(new DataPoint1(1498588200000, 4400));
            dataPoints2.Add(new DataPoint1(1498674600000, 4020));
            dataPoints2.Add(new DataPoint1(1498761000000, 3900));

            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            return View();
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