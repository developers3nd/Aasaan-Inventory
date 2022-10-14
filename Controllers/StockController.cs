using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using online_store.Models;

namespace online_store.Controllers
{
    public class StockController : Controller
    {
        private dbonlinestoreEntities db = new dbonlinestoreEntities();

        // GET: Stock
        public ActionResult Index()
        {
            var tblstocks = db.tblstocks.Include(t => t.tblproduct).Include(t => t.tblsupplier);
            return View(tblstocks.ToList());
        }

        // GET: Stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstock tblstock = db.tblstocks.Find(id);
            if (tblstock == null)
            {
                return HttpNotFound();
            }
            return View(tblstock);
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            ViewBag.pid = new SelectList(db.tblproducts, "pid", "name");
            ViewBag.sid = new SelectList(db.tblsuppliers, "sid", "sname");
            return View();
        }

        // POST: Stock/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stockid,pid,sid,qty,expirary_date")] tblstock tblstock)
        {
            if (ModelState.IsValid)
            {
                db.tblstocks.Add(tblstock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pid = new SelectList(db.tblproducts, "pid", "name", tblstock.pid);
            ViewBag.sid = new SelectList(db.tblsuppliers, "sid", "sname", tblstock.sid);
            return View(tblstock);
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstock tblstock = db.tblstocks.Find(id);
            if (tblstock == null)
            {
                return HttpNotFound();
            }
            ViewBag.pid = new SelectList(db.tblproducts, "pid", "name", tblstock.pid);
            ViewBag.sid = new SelectList(db.tblsuppliers, "sid", "sname", tblstock.sid);
            return View(tblstock);
        }

        // POST: Stock/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stockid,pid,sid,qty,expirary_date")] tblstock tblstock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pid = new SelectList(db.tblproducts, "pid", "name", tblstock.pid);
            ViewBag.sid = new SelectList(db.tblsuppliers, "sid", "sname", tblstock.sid);
            return View(tblstock);
        }

        // GET: Stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstock tblstock = db.tblstocks.Find(id);
            if (tblstock == null)
            {
                return HttpNotFound();
            }
            return View(tblstock);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblstock tblstock = db.tblstocks.Find(id);
            db.tblstocks.Remove(tblstock);
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
