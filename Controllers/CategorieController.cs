using online_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace online_store.Controllers
{
    public class CategorieController : Controller
    {
        dbonlinestoreEntities db = new dbonlinestoreEntities();
        public ActionResult AddCategorie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategorie(tblcategory c)
        {
            if(c != null){
                db.tblcategories.Add(c);
                db.SaveChanges();
                ViewBag.Msg = ("Catagorie Add Succefully");
            }
            else
            {
                ViewBag.Msg = ("Canot Add Categories");
            }
            
            return View();
        }
        public ActionResult ViewCategory()
        {
            var query = db.tblcategories.ToList();
            return View(query);

        }
        public ActionResult Edit(int catid)
        {
            var query = db.tblcategories.SingleOrDefault(modal => modal.catid == catid);
            return View(query);

        }
        [HttpPost]
        public ActionResult Edit(tblcategory c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction ("ViewCategory");

        }
        public ActionResult Delete(int catid)
        {
            var query = db.tblcategories.SingleOrDefault(modal => modal.catid == catid);
            db.tblcategories.Remove(query);
            db.SaveChanges();
            return RedirectToAction("ViewCategory");

        }

    }
}