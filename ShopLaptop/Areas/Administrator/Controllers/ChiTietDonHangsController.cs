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
    public class ChiTietDonHangsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/ChiTietDonHangs
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                var chiTietDonHangs = db.ChiTietDonHangs.Include(c => c.DonHang).Include(c => c.Laptop);
                return View(chiTietDonHangs.ToList());
            }
        }

        // GET: Administrator/ChiTietDonHangs/Details/5
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
                ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
                if (chiTietDonHang == null)
                {
                    return HttpNotFound();
                }
                return View(chiTietDonHang);
            }
        }

        // GET: Administrator/ChiTietDonHangs/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                ViewBag.madon = new SelectList(db.DonHangs, "madon", "madon");
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop");
                return View();
            }
        }

        // POST: Administrator/ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madon,malaptop,soluong,dongia")] ChiTietDonHang chiTietDonHang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.ChiTietDonHangs.Add(chiTietDonHang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.madon = new SelectList(db.DonHangs, "madon", "madon", chiTietDonHang.madon);
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop", chiTietDonHang.malaptop);
                return View(chiTietDonHang);
            }
        }

        // GET: Administrator/ChiTietDonHangs/Edit/5
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
                ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
                if (chiTietDonHang == null)
                {
                    return HttpNotFound();
                }
                ViewBag.madon = new SelectList(db.DonHangs, "madon", "madon", chiTietDonHang.madon);
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop", chiTietDonHang.malaptop);
                return View(chiTietDonHang);
            }
        }

        // POST: Administrator/ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madon,malaptop,soluong,dongia")] ChiTietDonHang chiTietDonHang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(chiTietDonHang).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.madon = new SelectList(db.DonHangs, "madon", "madon", chiTietDonHang.madon);
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop", chiTietDonHang.malaptop);
                return View(chiTietDonHang);
            }
        }

        // GET: Administrator/ChiTietDonHangs/Delete/5
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
                ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
                if (chiTietDonHang == null)
                {
                    return HttpNotFound();
                }
                return View(chiTietDonHang);
            }
        }

        // POST: Administrator/ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
                db.ChiTietDonHangs.Remove(chiTietDonHang);
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
