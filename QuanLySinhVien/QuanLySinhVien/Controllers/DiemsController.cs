using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Controllers
{
    public class DiemsController : Controller
    {
        private QLSVcontext db = new QLSVcontext();

        // GET: Diems

        public ActionResult Index()
        {
            var diems = db.Diems.Include(d => d.MonHocs).Include(d => d.SinhVienS);
            return View(diems.ToList());
        }

        // GET: Diems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diems/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MaMon = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc");
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien");
            return View();
        }

        // POST: Diems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBangDiem,MaSinhVien,MaMon,DiemHeA,DiemHeB,DiemHeC")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMon = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMon);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien", diem.MaSinhVien);
            return View(diem);
        }

        // GET: Diems/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMon = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMon);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien", diem.MaSinhVien);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBangDiem,MaSinhVien,MaMon,DiemHeA,DiemHeB,DiemHeC")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMon = new SelectList(db.MonHocs, "MaMonHoc", "TenMonHoc", diem.MaMon);
            ViewBag.MaSinhVien = new SelectList(db.SinhViens, "MaSinhVien", "TenSinhVien", diem.MaSinhVien);
            return View(diem);
        }

        // GET: Diems/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diem diem = db.Diems.Find(id);
            db.Diems.Remove(diem);
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
