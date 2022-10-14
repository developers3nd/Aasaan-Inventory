using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using online_store.Models;

namespace online_store.Controllers
{
    public class ProductController : Controller
    {
        dbonlinestoreEntities db = new dbonlinestoreEntities();

      

        public ActionResult NewProduct()
        {
            List<tblcategory> lst = db.tblcategories.ToList();
            ViewBag.catList = new SelectList(lst, "catid", "catname");

            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(tblproduct p, HttpPostedFileBase pimage)
        {
            List<tblcategory> lst = db.tblcategories.ToList();
            ViewBag.catList = new SelectList(lst, "catid", "catname");

            var folder = Server.MapPath("~/Uploads/");
            pimage.SaveAs(Path.Combine(folder, pimage.FileName.ToString()));

            p.pimage = pimage.FileName.ToString();


            db.tblproducts.Add(p);
            db.SaveChanges();

            return RedirectToAction("ViewProduct");

 
        }

        public ActionResult ViewProduct()
        {
            return View(db.tblproducts.ToList());
        }

        public ActionResult Edit(int pid)
        {
            List<tblcategory> lst = db.tblcategories.ToList();
            ViewBag.catList = new SelectList(lst, "catid", "catname");

            var query = db.tblproducts.SingleOrDefault(m => m.pid == pid);
            return View(query);
        }

        [HttpPost]
        public ActionResult Edit(tblproduct p, HttpPostedFileBase pimage)
        {
            List<tblcategory> lst = db.tblcategories.ToList();
            ViewBag.catList = new SelectList(lst, "catid", "catname");

            var folder = Server.MapPath("~/Uploads/");
            pimage.SaveAs(Path.Combine(folder, pimage.FileName.ToString()));

            p.pimage = pimage.FileName.ToString();


            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ViewProduct");
        }

        public ActionResult Delete(int pid)
        {
            var query = db.tblproducts.SingleOrDefault(m => m.pid == pid);

            db.tblproducts.Remove(query);
            db.SaveChanges();

            return RedirectToAction("ViewProduct");

        }


    }
}