using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkTogether.Models;

namespace WorkTogether.Controllers
{
    public class WorkWeeksController : Controller
    {
        private WorkContext db = new WorkContext();

        // GET: WorkWeeks
        public ActionResult Index()
        {
            var workWeek = db.WorkWeek.Include(w => w.User);
            return View(workWeek.ToList());
        }

        // GET: WorkWeeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkWeek workWeek = db.WorkWeek.Find(id);
            if (workWeek == null)
            {
                return HttpNotFound();
            }
            return View(workWeek);
        }

        // GET: WorkWeeks/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: WorkWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartWeek,UserId")] WorkWeek workWeek)
        {
            if (ModelState.IsValid)
            {
                db.WorkWeek.Add(workWeek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", workWeek.UserId);
            return View(workWeek);
        }

        // GET: WorkWeeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkWeek workWeek = db.WorkWeek.Find(id);
            if (workWeek == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", workWeek.UserId);
            return View(workWeek);
        }

        // POST: WorkWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartWeek,UserId")] WorkWeek workWeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workWeek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", workWeek.UserId);
            return View(workWeek);
        }

        // GET: WorkWeeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkWeek workWeek = db.WorkWeek.Find(id);
            if (workWeek == null)
            {
                return HttpNotFound();
            }
            return View(workWeek);
        }

        // POST: WorkWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkWeek workWeek = db.WorkWeek.Find(id);
            db.WorkWeek.Remove(workWeek);
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
