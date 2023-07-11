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
    public class ChucNangsController : Controller
    {
        private QuanLyTrungTamThuongMaiEntities4 db = new QuanLyTrungTamThuongMaiEntities4();

        // GET: ChucNangs
        public ActionResult Index()
        {
            return View(db.ChucNangs.ToList());
        }

        // GET: ChucNangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucNang chucNang = db.ChucNangs.Find(id);
            if (chucNang == null)
            {
                return HttpNotFound();
            }
            return View(chucNang);
        }

        // GET: ChucNangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChucNangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCN,TenCN")] ChucNang chucNang)
        {
            if (ModelState.IsValid)
            {
                db.ChucNangs.Add(chucNang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chucNang);
        }

        // GET: ChucNangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucNang chucNang = db.ChucNangs.Find(id);
            if (chucNang == null)
            {
                return HttpNotFound();
            }
            return View(chucNang);
        }

        // POST: ChucNangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCN,TenCN")] ChucNang chucNang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucNang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chucNang);
        }

        // GET: ChucNangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucNang chucNang = db.ChucNangs.Find(id);
            if (chucNang == null)
            {
                return HttpNotFound();
            }
            return View(chucNang);
        }

        // POST: ChucNangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChucNang chucNang = db.ChucNangs.Find(id);
            db.ChucNangs.Remove(chucNang);
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
