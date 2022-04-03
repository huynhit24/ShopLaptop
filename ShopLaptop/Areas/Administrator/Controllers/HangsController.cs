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
    public class HangsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/Hangs
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View(db.Hangs.ToList());
            }
        }

        // GET: Administrator/Hangs/Details/5
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
                Hang hang = db.Hangs.Find(id);
                if (hang == null)
                {
                    return HttpNotFound();
                }
                return View(hang);
            }
        }

        // GET: Administrator/Hangs/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View();
            }
        }

        // POST: Administrator/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahang,tenhang,hinh")] Hang hang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(hang);
            }
        }

        // GET: Administrator/Hangs/Edit/5
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
                Hang hang = db.Hangs.Find(id);
                if (hang == null)
                {
                    return HttpNotFound();
                }
                return View(hang);
            }
        }

        // POST: Administrator/Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahang,tenhang,hinh")] Hang hang)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(hang).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(hang);
            }
        }

        // GET: Administrator/Hangs/Delete/5
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
                Hang hang = db.Hangs.Find(id);
                if (hang == null)
                {
                    return HttpNotFound();
                }
                return View(hang);
            }
        }

        // POST: Administrator/Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                Hang hang = db.Hangs.Find(id);
                db.Hangs.Remove(hang);
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
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return file.FileName;
        }
    }
}
