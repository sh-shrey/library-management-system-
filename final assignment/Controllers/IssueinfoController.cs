using final_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final_assignment.Controllers
{
    public class IssueinfoController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Issueinfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMid(int mid)
        {
            var memberid = (from t in db.issuebooks
                            where t.m_id == mid
                            select new
                            {
                                issuedate = t.issuedate,
                                Returndate = t.returndate,
                                memberid = t.m_id,
                                bookname = t.book_id,
                            }).ToArray();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }

    }
}