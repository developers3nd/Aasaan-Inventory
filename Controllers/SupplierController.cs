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
    public class SupplierController : Controller
    {
        private dbonlinestoreEntities db = new dbonlinestoreEntities();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.tblsuppliers.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsupplier tblsupplier = db.tblsuppliers.Find(id);
            if (tblsupplier == null)
            {
                return HttpNotFound();
            }
            return View(tblsupplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sid,sname,contact,adress,status")] tblsupplier tblsupplier)
        {
            if (ModelState.IsValid)
            {
                db.tblsuppliers.Add(tblsupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblsupplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsupplier tblsupplier = db.tblsuppliers.Find(id);
            if (tblsupplier == null)
            {
                return HttpNotFound();
            }
            return View(tblsupplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sid,sname,contact,adress,status")] tblsupplier tblsupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblsupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblsupplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblsupplier tblsupplier = db.tblsuppliers.Find(id);
            if (tblsupplier == null)
            {
                return HttpNotFound();
            }
            return View(tblsupplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblsupplier tblsupplier = db.tblsuppliers.Find(id);
            db.tblsuppliers.Remove(tblsupplier);
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
