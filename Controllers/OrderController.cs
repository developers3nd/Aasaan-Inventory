using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using online_store;
using online_store.Models;

namespace online_store.Controllers
{
    public class OrderController : Controller
    {
        dbonlinestoreEntities db = new dbonlinestoreEntities();

        public ActionResult Orderbook()
        {
            List<stock_items> prolst = db.stock_items.ToList();
            ViewBag.ProList = new SelectList(prolst, "pid", "name");

            return View();
        }
        [HttpPost]
        public ActionResult Orderbook(tblorder o)
        {
            //List<tblproduct> lst = db.tblproducts.ToList();
            List<stock_items> prolst = db.stock_items.ToList();
            ViewBag.ProList = new SelectList(prolst, "pid", "name");

            int stock = 0;
            var query = db.tblstocks.SingleOrDefault(modal => modal.pid == o.pid);

            if (query != null)
            {
                stock = Convert.ToInt32((query.qty - o.qty));
                query.qty = stock;
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();
            }

            db.tblorders.Add(o);
            db.SaveChanges();

            return RedirectToAction("Vieworder");
        }

        public JsonResult GetItemPrice(int pid)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<stock_items> item_price = db.stock_items.Where(m => m.pid == pid).ToList();
            return Json(item_price, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetPrice(int itemcode)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<tblproduct> item_price = db.tblproducts.Where(m => m.itemcode == itemcode).ToList();
            return Json(item_price, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ViewOrder()
        {
            var query = db.myinvoices.ToList();
            return View(query);

        }

        public JsonResult GetName(string name)
        {

            db.Configuration.ProxyCreationEnabled = false;

            var query = db.myinvoices.Where(m => m.name.Contains(name));

            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSearch(DateTime str, DateTime end)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var query = from x in db.myinvoices where x.date >= str && x.date <= end select x;
            return Json(query.ToList(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult Searchorder()
        {
            return View();
        }
        public ActionResult Invoice(int orderid)
        {
            var query = db.myinvoices.SingleOrDefault(m => m.orderid == orderid);
            return View(query);
        }

        public ActionResult BarcodeSale()
        {

            return View();
        }

        [HttpPost]
        public ActionResult BarcodeSale(tblorder o)
        {
            int stock = 0;
            var query = db.tblstocks.SingleOrDefault(modal => modal.pid == o.pid);

            if (query != null)
            {
                stock = Convert.ToInt32((query.qty - o.qty));
                query.qty = stock;
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();
            }

            db.tblorders.Add(o);
            db.SaveChanges();

            return RedirectToAction("ViewOrder");
        }


    
    }
}