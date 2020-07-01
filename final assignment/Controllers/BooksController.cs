using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using final_assignment.Models;

namespace final_assignment.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Books
        public ActionResult Index(string searchby,string search)
        {
            if (searchby == "book_name")
            {
                var books = db.books.Include(b => b.author).Include(b => b.category).Include(b => b.publisher);
                var model = db.books.Where(t => t.book_name == search || search == null).ToList();
                return View(model);


            }
            else
            {
                var books = db.books.Include(b => b.author).Include(b => b.category).Include(b => b.publisher);
                var model = db.books.Where(t => t.edition == search || search == null).ToList();
                return View(model);
            }
            //var books = db.books.Include(b => b.author).Include(b => b.category).Include(b => b.publisher);
            //return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.a_id = new SelectList(db.authors, "Id", "author_name");
            ViewBag.cat_id = new SelectList(db.categories, "Id", "category_name");
            ViewBag.p_id = new SelectList(db.publishers, "Id", "name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,book_name,cat_id,a_id,p_id,about,pages,edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.a_id = new SelectList(db.authors, "Id", "author_name", book.a_id);
            ViewBag.cat_id = new SelectList(db.categories, "Id", "category_name", book.cat_id);
            ViewBag.p_id = new SelectList(db.publishers, "Id", "name", book.p_id);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.a_id = new SelectList(db.authors, "Id", "author_name", book.a_id);
            ViewBag.cat_id = new SelectList(db.categories, "Id", "category_name", book.cat_id);
            ViewBag.p_id = new SelectList(db.publishers, "Id", "name", book.p_id);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,book_name,cat_id,a_id,p_id,about,pages,edition")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.a_id = new SelectList(db.authors, "Id", "author_name", book.a_id);
            ViewBag.cat_id = new SelectList(db.categories, "Id", "category_name", book.cat_id);
            ViewBag.p_id = new SelectList(db.publishers, "Id", "name", book.p_id);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
