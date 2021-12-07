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
    public class SinhViensController : Controller
    {
        private QLSVcontext db = new QLSVcontext();

        // GET: SinhViens\[Authorize]
        [Authorize]
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.ChuyenNganhs).Include(s => s.Khoas).Include(s => s.LopHocs);
            return View(sinhViens.ToList());
        }
        [Authorize]
        // GET: SinhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }
        [Authorize]
        // GET: SinhViens/Create
        public ActionResult Create()
        {
            ViewBag.MaNganh = new SelectList(db.Nganhs, "MaNganh", "TenNganh");
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            return View();
        }
        [Authorize]
        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSinhVien,TenSinhVien,NgaySinh,QueQuan,MaLop,MaKhoa,MaNganh,MaBangDiem")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNganh = new SelectList(db.Nganhs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", sinhVien.MaKhoa);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }
        [Authorize]
        // GET: SinhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNganh = new SelectList(db.Nganhs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", sinhVien.MaKhoa);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSinhVien,TenSinhVien,NgaySinh,QueQuan,MaLop,MaKhoa,MaNganh,MaBangDiem")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNganh = new SelectList(db.Nganhs, "MaNganh", "TenNganh", sinhVien.MaNganh);
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", sinhVien.MaKhoa);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        [Authorize]
        // GET: SinhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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
