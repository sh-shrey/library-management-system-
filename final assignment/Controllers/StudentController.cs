using final_assignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final_assignment.Controllers
{
    public class StudentController : Controller
    {
        Database1Entities db = new Database1Entities();
        
        // GET: Student
        public ActionResult Newstudent()
        {
            return View();
        }
        public ActionResult SaveData(student item)
        {
            if (item.name != null && item.year != null && item.stream != null && item.imageupload != null)
            {
                string filename = Path.GetFileNameWithoutExtension(item.imageupload.FileName);
                string extension = Path.GetExtension(item.imageupload.FileName);
               // filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                item.image = filename;
                item.imageupload.SaveAs(Path.Combine(Server.MapPath("~/AppFile/pics"), filename));
                db.students.Add(item);
                db.SaveChanges();
                    }
            var result = "Successfully Added";
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}