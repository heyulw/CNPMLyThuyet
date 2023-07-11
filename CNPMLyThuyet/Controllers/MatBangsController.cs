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
    public class MatBangsController : Controller
    {
        private QuanLyTrungTamThuongMaiEntities4 db = new QuanLyTrungTamThuongMaiEntities4();

        // GET: MatBangs
        public ActionResult Index()
        {
            var matBangs = db.MatBangs.Include(m => m.HopDong).Include(m => m.KhachHang).Include(m => m.Tang);
            return View(matBangs.ToList());
        }

        // GET: MatBangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatBang matBang = db.MatBangs.Find(id);
            if (matBang == null)
            {
                return HttpNotFound();
            }
            return View(matBang);
        }

        // GET: MatBangs/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "MaHD");
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen");
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang");
            return View();
        }

        // POST: MatBangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMB,TenMB,TinhTrang,GiaTien,MaTang,MaKH,MaHD")] MatBang matBang)
        {
            if (ModelState.IsValid)
            {
                db.MatBangs.Add(matBang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "MaHD", matBang.MaHD);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen", matBang.MaKH);
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang", matBang.MaTang);
            return View(matBang);
        }

        // GET: MatBangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatBang matBang = db.MatBangs.Find(id);
            if (matBang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "MaHD", matBang.MaHD);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen", matBang.MaKH);
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang", matBang.MaTang);
            return View(matBang);
        }

        // POST: MatBangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMB,TenMB,TinhTrang,GiaTien,MaTang,MaKH,MaHD")] MatBang matBang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matBang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HopDongs, "MaHD", "MaHD", matBang.MaHD);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoVaTen", matBang.MaKH);
            ViewBag.MaTang = new SelectList(db.Tangs, "MaTang", "TenTang", matBang.MaTang);
            return View(matBang);
        }

        // GET: MatBangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatBang matBang = db.MatBangs.Find(id);
            if (matBang == null)
            {
                return HttpNotFound();
            }
            return View(matBang);
        }

        // POST: MatBangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MatBang matBang = db.MatBangs.Find(id);
            db.MatBangs.Remove(matBang);
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
