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
    public class HopDongsController : Controller
    {
        private QuanLyTrungTamThuongMaiEntities4 db = new QuanLyTrungTamThuongMaiEntities4();

        // GET: HopDongs
        public ActionResult Index()
        {
            return View(db.HopDongs.ToList());
        }

        // GET: HopDongs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDongs.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // GET: HopDongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HopDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayKi,NgayHetHan")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                db.HopDongs.Add(hopDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hopDong);
        }

        // GET: HopDongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDongs.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // POST: HopDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayKi,NgayHetHan")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hopDong);
        }

        // GET: HopDongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDongs.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // POST: HopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HopDong hopDong = db.HopDongs.Find(id);
            db.HopDongs.Remove(hopDong);
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
