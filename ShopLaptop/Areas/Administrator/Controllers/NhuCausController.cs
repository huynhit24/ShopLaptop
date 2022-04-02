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
    public class NhuCausController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/NhuCaus
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View(db.NhuCaus.ToList());
            }
        }

        // GET: Administrator/NhuCaus/Details/5
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
                NhuCau nhuCau = db.NhuCaus.Find(id);
                if (nhuCau == null)
                {
                    return HttpNotFound();
                }
                return View(nhuCau);
            }
        }

        // GET: Administrator/NhuCaus/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View();
            }
        }

        // POST: Administrator/NhuCaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manhucau,tennhucau")] NhuCau nhuCau)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.NhuCaus.Add(nhuCau);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(nhuCau);
            }
        }

        // GET: Administrator/NhuCaus/Edit/5
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
                NhuCau nhuCau = db.NhuCaus.Find(id);
                if (nhuCau == null)
                {
                    return HttpNotFound();
                }
                return View(nhuCau);
            }
        }

        // POST: Administrator/NhuCaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manhucau,tennhucau")] NhuCau nhuCau)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(nhuCau).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(nhuCau);
            }
        }

        // GET: Administrator/NhuCaus/Delete/5
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
                NhuCau nhuCau = db.NhuCaus.Find(id);
                if (nhuCau == null)
                {
                    return HttpNotFound();
                }
                return View(nhuCau);
            }
        }

        // POST: Administrator/NhuCaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                NhuCau nhuCau = db.NhuCaus.Find(id);
                db.NhuCaus.Remove(nhuCau);
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
