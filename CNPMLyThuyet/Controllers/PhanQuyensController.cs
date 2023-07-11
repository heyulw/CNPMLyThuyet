using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMLyThuyet.Model;

namespace CNPMLyThuyet.Controllers
{
    public class PhanQuyensController : Controller
    {
        private QuanLyTrungTamThuongMaiEntities4 db = new QuanLyTrungTamThuongMaiEntities4();

        // GET: PhanQuyens
        public ActionResult Index()
        {
            var phanQuyens = db.PhanQuyens.Include(p => p.ChucNang).Include(p => p.PhongBan);
            return View(phanQuyens.ToList());
        }

        // GET: PhanQuyens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Create
        public ActionResult Create()
        {
            ViewBag.MaCN = new SelectList(db.ChucNangs, "MaCN", "TenCN");
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB");
            return View();
        }

        // POST: PhanQuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,MaPB,MaCN")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                db.PhanQuyens.Add(phanQuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCN = new SelectList(db.ChucNangs, "MaCN", "TenCN", phanQuyen.MaCN);
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", phanQuyen.MaPB);
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCN = new SelectList(db.ChucNangs, "MaCN", "TenCN", phanQuyen.MaCN);
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", phanQuyen.MaPB);
            return View(phanQuyen);
        }

        // POST: PhanQuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,MaPB,MaCN")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanQuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCN = new SelectList(db.ChucNangs, "MaCN", "TenCN", phanQuyen.MaCN);
            ViewBag.MaPB = new SelectList(db.PhongBans, "MaPB", "TenPB", phanQuyen.MaPB);
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            return View(phanQuyen);
        }

        // POST: PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            db.PhanQuyens.Remove(phanQuyen);
            db.SaveChanges();
            return RedirectToAction("Index");
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
