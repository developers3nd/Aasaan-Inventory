using online_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace online_store.Controllers
{
    public class AccountsController : Controller
    {
        dbonlinestoreEntities db = new dbonlinestoreEntities(); 
        public ActionResult Dashboard()
        {
            var category = db.tblcategories.Count();
            ViewBag.CatList = category;

            var items = db.tblproducts.Count();
            ViewBag.ItemList = items;

            var order = db.tblorders.Count();
            ViewBag.OrderList = order;

            var stock = db.tblstocks.Count();
            ViewBag.StockList = stock;

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
           
            var query = db.tblusers.SingleOrDefault(m => m.email == email && m.password == password);
            if(query!= null)
            {
                if(query.Roleid == 1)
                {
                    FormsAuthentication.SetAuthCookie(query.email, false);

                    Session["email"] = query.email;
                    Session["UID"] = query.userid;
                    return RedirectToAction("Dashboard");

                }
                else if(query.Roleid == 2)
                {
                    FormsAuthentication.SetAuthCookie(query.email, false);  
                    Session["email"] = query.email;
                    Session["UID"] = query.userid;
                    return RedirectToAction("Dashboard");
                }
                
               
            }
            else
            {
                ViewBag.msg = "invalid email or password";
            }
            return View();
        } 
        public ActionResult Logout()
        {
            //Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}