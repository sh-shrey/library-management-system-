using final_assignment.Models;
using System;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Mvc;

namespace final_assignment.Controllers
{
    public class ReturnController : Controller
    {
        Database1Entities db = new Database1Entities();
        
        // GET: Return
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(returnbook returns)
        {
            if (ModelState.IsValid)
            {
                db.returnbooks.Add(returns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returns);

        }
       
        public ActionResult GetMid(int mid)
        {
            
            var memberid = (from s in db.issuebooks
                            where s.m_id == mid
                            select new
                            {
                                issuedate = s.issuedate,
                                Returndate = s.returndate,
                                memberid = s.m_id,
                                bookname = s.book_id,

                                // TimeSpan diffrence = DateTime.Now.Subtract(s.returndate),==> diff.days
                                ElapsedDays = SqlFunctions.DateDiff("day", DateTime.Now ,s.returndate)
                            }).ToArray();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }
    }
}