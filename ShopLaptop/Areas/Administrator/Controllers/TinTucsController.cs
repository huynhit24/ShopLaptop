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
    public class TinTucsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Administrator/TinTucs
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                var tinTucs = db.TinTucs.Include(t => t.ChuDe);
                return View(tinTucs.ToList());
            }
        }

        // GET: Administrator/TinTucs/Details/5
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
                TinTuc tinTuc = db.TinTucs.Find(id);
                if (tinTuc == null)
                {
                    return HttpNotFound();
                }
                return View(tinTuc);
            }
        }

        // GET: Administrator/TinTucs/Create
        public ActionResult Create()
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                ViewBag.machude = new SelectList(db.ChuDes, "machude", "tenchude");
                return View();
            }
        }

        // POST: Administrator/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]// mới thêm vô
        public ActionResult Create([Bind(Include = "matin,tieude,hinhnen,tomtat,slug,noidung,luotxem,ngaycapnhat,xuatban,machude")] TinTuc tinTuc)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.TinTucs.Add(tinTuc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.machude = new SelectList(db.ChuDes, "machude", "tenchude", tinTuc.machude);
                return View(tinTuc);
            }
        }

        // GET: Administrator/TinTucs/Edit/5
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
                TinTuc tinTuc = db.TinTucs.Find(id);
                if (tinTuc == null)
                {
                    return HttpNotFound();
                }
                ViewBag.machude = new SelectList(db.ChuDes, "machude", "tenchude", tinTuc.machude);
                return View(tinTuc);
            }
        }

        // POST: Administrator/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]// mới thêm vô
        public ActionResult Edit([Bind(Include = "matin,tieude,hinhnen,tomtat,slug,noidung,luotxem,ngaycapnhat,xuatban,machude")] TinTuc tinTuc)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tinTuc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.machude = new SelectList(db.ChuDes, "machude", "tenchude", tinTuc.machude);
                return View(tinTuc);
            }
        }

        // GET: Administrator/TinTucs/Delete/5
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
                TinTuc tinTuc = db.TinTucs.Find(id);
                if (tinTuc == null)
                {
                    return HttpNotFound();
                }
                return View(tinTuc);
            }
        }

        // POST: Administrator/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["taikhoanadmin"] == null)
                return RedirectToAction("Login", "MainPage");
            else
            {
                TinTuc tinTuc = db.TinTucs.Find(id);
                db.TinTucs.Remove(tinTuc);
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
