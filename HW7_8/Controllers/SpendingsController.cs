using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7_8;

namespace HW7_8.Controllers
{
    public class SpendingsController : Controller
    {
        private SpendsDb db = new SpendsDb();

        public ActionResult Index()
        {
            var spendings = db.Spendings.Include(s => s.Categories);
            return View(spendings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spendings spendings = db.Spendings.Find(id);
            if (spendings == null)
            {
                return HttpNotFound();
            }
            return View(spendings);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,Price,Comment,Date")] Spendings spendings)
        {
            if (ModelState.IsValid)
            {
                db.Spendings.Add(spendings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", spendings.CategoryId);
            return View(spendings);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spendings spendings = db.Spendings.Find(id);
            if (spendings == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", spendings.CategoryId);
            return View(spendings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,Price,Comment,Date")] Spendings spendings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spendings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", spendings.CategoryId);
            return View(spendings);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spendings spendings = db.Spendings.Find(id);
            if (spendings == null)
            {
                return HttpNotFound();
            }
            return View(spendings);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spendings spendings = db.Spendings.Find(id);
            db.Spendings.Remove(spendings);
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
