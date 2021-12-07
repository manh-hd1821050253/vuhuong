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
    public class ChuyenNganhsController : Controller
    {
        private QLSVcontext db = new QLSVcontext();

        // GET: ChuyenNganhs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Nganhs.ToList());
        }

        // GET: ChuyenNganhs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.Nganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            return View(chuyenNganh);
        }

        // GET: ChuyenNganhs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChuyenNganhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNganh,TenNganh,NgayThanhLapChuyenNganh")] ChuyenNganh chuyenNganh)
        {
            if (ModelState.IsValid)
            {
                db.Nganhs.Add(chuyenNganh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chuyenNganh);
        }
        [Authorize]
        // GET: ChuyenNganhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.Nganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            return View(chuyenNganh);
        }

        // POST: ChuyenNganhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "MaNganh,TenNganh,NgayThanhLapChuyenNganh")] ChuyenNganh chuyenNganh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenNganh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuyenNganh);
        }

        [Authorize]
        // GET: ChuyenNganhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuyenNganh chuyenNganh = db.Nganhs.Find(id);
            if (chuyenNganh == null)
            {
                return HttpNotFound();
            }
            return View(chuyenNganh);
        }

        // POST: ChuyenNganhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuyenNganh chuyenNganh = db.Nganhs.Find(id);
            db.Nganhs.Remove(chuyenNganh);
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
