using online_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_store.Controllers
{



    public class HomeController : Controller
    {
        dbonlinestoreEntities db = new dbonlinestoreEntities();
    

        public ActionResult Index()
        {
            var query = db.tblproducts.ToList();
            return View(query);
        }
        public ActionResult back()
        {
            var query = db.tblproducts.ToList();
            return View(query);
        }

        //public ActionResult AddtoCart(int id)
        //{
        //    var query = db.tblproducts.Where(x => x.pid == id).SingleOrDefault();
        //    return View(query);
        //}

        //[HttpPost]
        //public ActionResult AddtoCart(int id, int qty)
        //{
        //    tblproduct p = db.tblproducts.Where(x => x.pid == id).SingleOrDefault();
        //    Cart c = new Cart();
        //    c.proid = id;
        //    c.proname = p.name;
        //    c.price = Convert.ToInt32(p.qty);
        //    c.qty = Convert.ToInt32(qty);
        //    c.bill = c.price * c.qty;
        //    if (TempData["cart"] == null)
        //    {
        //        li.ADD(c);
        //        TempData["cart"] = li;
        //    }
        //    else
        //    {
        //        List<Cart> li2 = TempData["cart"] as List<Cart>;
        //        int flag = 0;
        //        foreach (var item in li2)
        //        {
        //            if (item.proid == c.proid)
        //            {
        //                item.qty += c.qty;
        //                item.bill += c.bill;
        //                flag = 1;
        //            }

        //        }
        //        if (flag == 0)
        //        {
        //            li2.Add(c);
        //            //new item
        //        }
        //        TempData["cart"] = li2;

        //    }

        //    TempData.Keep();

        //    return RedirectToAction("Index");
        //}
        public ActionResult Orderbook(int pid)
        {

            Session["pid"] = pid;
            return View();
        }
        [HttpPost]
        public ActionResult Orderbook(tblorder o, int pid)
        {
            o.pid = pid;
            db.tblorders.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}




