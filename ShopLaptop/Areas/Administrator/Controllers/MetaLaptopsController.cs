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
    public class MetaLaptopsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/MetaLaptops
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                var metaLaptops = db.MetaLaptops.Include(m => m.Laptop);
                return View(metaLaptops.ToList());
            }
        }

        // GET: Administrator/MetaLaptops/Details/5
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
                MetaLaptop metaLaptop = db.MetaLaptops.Find(id);
                if (metaLaptop == null)
                {
                    return HttpNotFound();
                }
                return View(metaLaptop);
            }
        }

        // GET: Administrator/MetaLaptops/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop");
                return View();
            }
        }

        // POST: Administrator/MetaLaptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mameta,keymeta,valuemeta,malaptop")] MetaLaptop metaLaptop)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.MetaLaptops.Add(metaLaptop);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop", metaLaptop.malaptop);
                return View(metaLaptop);
            }
        }

        // GET: Administrator/MetaLaptops/Edit/5
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
                MetaLaptop metaLaptop = db.MetaLaptops.Find(id);
                if (metaLaptop == null)
                {
                    return HttpNotFound();
                }
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop", metaLaptop.malaptop);
                return View(metaLaptop);
            }
        }

        // POST: Administrator/MetaLaptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mameta,keymeta,valuemeta,malaptop")] MetaLaptop metaLaptop)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(metaLaptop).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.malaptop = new SelectList(db.Laptops, "malaptop", "tenlaptop", metaLaptop.malaptop);
                return View(metaLaptop);
            }
        }

        // GET: Administrator/MetaLaptops/Delete/5
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
                MetaLaptop metaLaptop = db.MetaLaptops.Find(id);
                if (metaLaptop == null)
                {
                    return HttpNotFound();
                }
                return View(metaLaptop);
            }
        }

        // POST: Administrator/MetaLaptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                MetaLaptop metaLaptop = db.MetaLaptops.Find(id);
                db.MetaLaptops.Remove(metaLaptop);
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
