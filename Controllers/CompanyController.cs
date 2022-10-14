using online_store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_store.Controllers
{
    public class CompanyController : Controller
    {
        dbonlinestoreEntities db = new dbonlinestoreEntities();
 
        public ActionResult AddCompany()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(tblcompany c, HttpPostedFileBase cimage)
        {
            if (ModelState.IsValid)
            {


              
                    var folder = Server.MapPath("~/Uploads/");
                    cimage.SaveAs(Path.Combine(folder, cimage.FileName.ToString()));



                    c.cimage = cimage.FileName.ToString();

                    db.tblcompanies.Add(c);
                    db.SaveChanges();

           



            }



            return RedirectToAction("ViewCompany");
        }

        public ActionResult ViewCompany()
        {
            return View(db.tblcompanies.ToList());
        }

        public ActionResult Edit(int cid)
        {
            
            var query = db.tblcompanies.SingleOrDefault(m => m.cid == cid);
            return View(query);
        }

        [HttpPost]
        public ActionResult Edit(tblcompany c, HttpPostedFileBase cimage)
        {
         

            var folder = Server.MapPath("~/Uploads/");
            cimage.SaveAs(Path.Combine(folder, cimage.FileName.ToString()));

            c.cimage = cimage.FileName.ToString();


            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ViewCompany");
        }

        public ActionResult Delete(int cid)
        {
            var query = db.tblcompanies.SingleOrDefault(m => m.cid == cid);

            db.tblcompanies.Remove(query);
            db.SaveChanges();

            return RedirectToAction("ViewCompany");

        }


    }
}