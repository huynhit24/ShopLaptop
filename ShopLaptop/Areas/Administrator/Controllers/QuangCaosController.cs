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
    public class QuangCaosController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/QuangCaos
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View(db.QuangCaos.ToList());
            }
        }

        // GET: Administrator/QuangCaos/Details/5
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
                QuangCao quangCao = db.QuangCaos.Find(id);
                if (quangCao == null)
                {
                    return HttpNotFound();
                }
                return View(quangCao);
            }
        }

        // GET: Administrator/QuangCaos/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                return View();
            }
        }

        // POST: Administrator/QuangCaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maqc,tenqc,tencongty,hinhnen,link,ngaybatdau,ngayhethan,trangthai")] QuangCao quangCao)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.QuangCaos.Add(quangCao);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(quangCao);
            }
        }

        // GET: Administrator/QuangCaos/Edit/5
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
                QuangCao quangCao = db.QuangCaos.Find(id);
                if (quangCao == null)
                {
                    return HttpNotFound();
                }
                return View(quangCao);
            }
        }

        // POST: Administrator/QuangCaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maqc,tenqc,tencongty,hinhnen,link,ngaybatdau,ngayhethan,trangthai")] QuangCao quangCao)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(quangCao).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(quangCao);
            }
        }

        // GET: Administrator/QuangCaos/Delete/5
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
                QuangCao quangCao = db.QuangCaos.Find(id);
                if (quangCao == null)
                {
                    return HttpNotFound();
                }
                return View(quangCao);
            }
        }

        // POST: Administrator/QuangCaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                QuangCao quangCao = db.QuangCaos.Find(id);
                db.QuangCaos.Remove(quangCao);
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
