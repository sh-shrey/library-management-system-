using final_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace final_assignment.Controllers
{
    public class LoginController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(master au)
        {
            string user = au.username;
            string pass = au.password;
            using (db)
            {
                string status;
                var use = (from s in db.masters
                           where s.username == user && s.password == pass
                           select s).FirstOrDefault();
                if (use != null)
                {
                    Session["username"] = use.username.ToString();
                    status = "1";
                }
                else
                {
                    status = "3";
                }
                return new JsonResult { Data = new { status = status }};
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "login");
        }
        
    }
}