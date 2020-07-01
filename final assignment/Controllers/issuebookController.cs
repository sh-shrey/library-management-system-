using final_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final_assignment.Controllers
{
    public class issuebookController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: issuebook
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Getbook()
        {
            var books = db.books.Select(p => new
            {
                ID = p.Id,
                book_name = p.book_name
            }).ToList();
            return Json(books, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult GetMid(int mid)
        {
            var memberid = (from s in db.students where s.Id == mid select s.name).ToList();
            return Json(memberid, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Save(issuebook issue)
        {
            if (ModelState.IsValid)
            {
                db.issuebooks.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
