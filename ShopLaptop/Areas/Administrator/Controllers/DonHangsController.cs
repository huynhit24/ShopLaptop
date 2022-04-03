using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopLaptop.EF;

namespace ShopLaptop.Areas.Administrator.Controllers
{
    public class DonHangsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/DonHangs
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                var donHangs = db.DonHangs.Include(d => d.KhachHang);
                return View(donHangs.ToList());
            }
        }

        // GET: Administrator/DonHangs/Details/5
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
                DonHang donHang = db.DonHangs.Find(id);
                if (donHang == null)
                {
                    return HttpNotFound();
                }
                return View(donHang);
            }
        }

        // GET: Administrator/DonHangs/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                ViewBag.makh = new SelectList(db.KhachHangs, "makh", "hoten");
                return View();
            }
        }

        // POST: Administrator/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madon,thanhtoan,giaohang,ngaydat,ngaygiao,makh")] DonHang donHang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.DonHangs.Add(donHang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.makh = new SelectList(db.KhachHangs, "makh", "hoten", donHang.makh);
                return View(donHang);
            }
        }

        // GET: Administrator/DonHangs/Edit/5
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
                DonHang donHang = db.DonHangs.Find(id);
                if (donHang == null)
                {
                    return HttpNotFound();
                }
                ViewBag.makh = new SelectList(db.KhachHangs, "makh", "hoten", donHang.makh);
                return View(donHang);
            }
        }

        // POST: Administrator/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madon,thanhtoan,giaohang,ngaydat,ngaygiao,makh")] DonHang donHang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(donHang).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.makh = new SelectList(db.KhachHangs, "makh", "hoten", donHang.makh);
                return View(donHang);
            }
        }

        // GET: Administrator/DonHangs/Delete/5
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
                DonHang donHang = db.DonHangs.Find(id);
                if (donHang == null)
                {
                    return HttpNotFound();
                }
                return View(donHang);
            }
        }

        // POST: Administrator/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                DonHang donHang = db.DonHangs.Find(id);
                db.DonHangs.Remove(donHang);
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
