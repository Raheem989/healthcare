using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectKidsHealthCenter.Models;

namespace FinalProjectKidsHealthCenter.Controllers
{
    public class MinistryRepresentatorsController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: MinistryRepresentators
        public ActionResult Index()
        {
            var ministryRepresentators = db.MinistryRepresentators.Include(m => m.GenderTable);
            return View(ministryRepresentators.ToList());
        }

        // GET: MinistryRepresentators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryRepresentator ministryRepresentator = db.MinistryRepresentators.Find(id);
            if (ministryRepresentator == null)
            {
                return HttpNotFound();
            }
            return View(ministryRepresentator);
        }

        // GET: MinistryRepresentators/Create
        public ActionResult Create()
        {
            ViewBag.GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName");
            return View();
        }

        // POST: MinistryRepresentators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MR_ID,MR_FName,MR_MiniName,MR_LName,GenderID,MR_Email,MR_PhoneNo")] MinistryRepresentator ministryRepresentator)
        {
            if (ModelState.IsValid)
            {
                db.MinistryRepresentators.Add(ministryRepresentator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", ministryRepresentator.GenderID);
            return View(ministryRepresentator);
        }

        // GET: MinistryRepresentators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryRepresentator ministryRepresentator = db.MinistryRepresentators.Find(id);
            if (ministryRepresentator == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", ministryRepresentator.GenderID);
            return View(ministryRepresentator);
        }

        // POST: MinistryRepresentators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MR_ID,MR_FName,MR_MiniName,MR_LName,GenderID,MR_Email,MR_PhoneNo")] MinistryRepresentator ministryRepresentator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministryRepresentator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", ministryRepresentator.GenderID);
            return View(ministryRepresentator);
        }

        // GET: MinistryRepresentators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryRepresentator ministryRepresentator = db.MinistryRepresentators.Find(id);
            if (ministryRepresentator == null)
            {
                return HttpNotFound();
            }
            return View(ministryRepresentator);
        }

        // POST: MinistryRepresentators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinistryRepresentator ministryRepresentator = db.MinistryRepresentators.Find(id);
            db.MinistryRepresentators.Remove(ministryRepresentator);
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
