using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopLaptop.EF;
using ShopLaptop.Common;

namespace ShopLaptop.Areas.Administrator.Controllers
{
    public class KhachHangsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/KhachHangs
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View(db.KhachHangs.ToList());
            }
        }

        // GET: Administrator/KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                KhachHang khachHang = db.KhachHangs.Find(id);
                if (khachHang == null)
                {
                    return HttpNotFound();
                }
                return View(khachHang);
            }
        }

        // GET: Administrator/KhachHangs/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View();
            }
        }

        // POST: Administrator/KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makh,hoten,tendangnhap,matkhau,email,diachi,dienthoai,ngaysinh")] KhachHang khachHang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    khachHang.matkhau = CommonFields.getStringSHA256Hash(khachHang.matkhau).Substring(0, 32);
                    db.KhachHangs.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(khachHang);
            }
        }

        // GET: Administrator/KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                KhachHang khachHang = db.KhachHangs.Find(id);
                if (khachHang == null)
                {
                    return HttpNotFound();
                }
                return View(khachHang);
            }
        }

        // POST: Administrator/KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makh,hoten,tendangnhap,matkhau,email,diachi,dienthoai,ngaysinh")] KhachHang khachHang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(khachHang).State = EntityState.Modified;
                    khachHang.matkhau = CommonFields.getStringSHA256Hash(khachHang.matkhau).Substring(0, 32);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(khachHang);
            }
        }

        // GET: Administrator/KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                KhachHang khachHang = db.KhachHangs.Find(id);
                if (khachHang == null)
                {
                    return HttpNotFound();
                }
                return View(khachHang);
            }
        }

        // POST: Administrator/KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                KhachHang khachHang = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
