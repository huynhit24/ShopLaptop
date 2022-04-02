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
    public class LienHesController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/LienHes
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View(db.LienHes.ToList());
            }
        }

        // GET: Administrator/LienHes/Details/5
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
                LienHe lienHe = db.LienHes.Find(id);
                if (lienHe == null)
                {
                    return HttpNotFound();
                }
                return View(lienHe);
            }
        }

        // GET: Administrator/LienHes/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View();
            }
        }

        // POST: Administrator/LienHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "malienhe,hoten,email,dienthoai,website,noidung,trangthai")] LienHe lienHe)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.LienHes.Add(lienHe);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(lienHe);
            }
        }

        // GET: Administrator/LienHes/Edit/5
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
                LienHe lienHe = db.LienHes.Find(id);
                if (lienHe == null)
                {
                    return HttpNotFound();
                }
                return View(lienHe);
            }
        }

        // POST: Administrator/LienHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "malienhe,hoten,email,dienthoai,website,noidung,trangthai")] LienHe lienHe)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(lienHe).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(lienHe);
            }
        }

        // GET: Administrator/LienHes/Delete/5
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
                LienHe lienHe = db.LienHes.Find(id);
                if (lienHe == null)
                {
                    return HttpNotFound();
                }
                return View(lienHe);
            }
        }

        // POST: Administrator/LienHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                LienHe lienHe = db.LienHes.Find(id);
                db.LienHes.Remove(lienHe);
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
