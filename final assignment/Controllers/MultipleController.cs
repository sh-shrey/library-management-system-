using final_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final_assignment.Controllers
{
    public class MultipleController : Controller
    {
        // GET: Multiple
        public ActionResult Index()
        {

            Database1Entities db = new Database1Entities();
            List<issuebook> issuebookies = db.issuebooks.ToList();
            List<returnbook> returnies = db.returnbooks.ToList();
            List<student> studentd = db.students.ToList();
            var multipletables = from c in issuebookies
                                 join rt in returnies on c.m_id equals rt.mid into table1
                                 from rt in table1.DefaultIfEmpty()
                                 join st in studentd on c.m_id equals st.Id into table2
                                 from st in table2.DefaultIfEmpty()
                                 select new Multipleclass1 { issuebookdetails = c, returndetails = rt, studentdetails=st };



            return View(multipletables);
        }
    }
}