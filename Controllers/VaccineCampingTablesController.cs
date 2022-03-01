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
    public class VaccineCampingTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: VaccineCampingTables
        public ActionResult Index()
        {
            var vaccineCampingTables = db.VaccineCampingTables.Include(v => v.MinistryRepresentator);
            return View(vaccineCampingTables.ToList());
        }

        // GET: VaccineCampingTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineCampingTable vaccineCampingTable = db.VaccineCampingTables.Find(id);
            if (vaccineCampingTable == null)
            {
                return HttpNotFound();
            }
            return View(vaccineCampingTable);
        }

        // GET: VaccineCampingTables/Create
        public ActionResult Create()
        {
            ViewBag.VC_MRID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName");
            return View();
        }

        // POST: VaccineCampingTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VC_ID,VC_MRID,VC_Name,VC_Description,VC_Date,VC_Time")] VaccineCampingTable vaccineCampingTable)
        {
            if (ModelState.IsValid)
            {
                db.VaccineCampingTables.Add(vaccineCampingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VC_MRID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName", vaccineCampingTable.VC_MRID);
            return View(vaccineCampingTable);
        }

        // GET: VaccineCampingTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineCampingTable vaccineCampingTable = db.VaccineCampingTables.Find(id);
            if (vaccineCampingTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.VC_MRID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName", vaccineCampingTable.VC_MRID);
            return View(vaccineCampingTable);
        }

        // POST: VaccineCampingTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VC_ID,VC_MRID,VC_Name,VC_Description,VC_Date,VC_Time")] VaccineCampingTable vaccineCampingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineCampingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VC_MRID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName", vaccineCampingTable.VC_MRID);
            return View(vaccineCampingTable);
        }

        // GET: VaccineCampingTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineCampingTable vaccineCampingTable = db.VaccineCampingTables.Find(id);
            if (vaccineCampingTable == null)
            {
                return HttpNotFound();
            }
            return View(vaccineCampingTable);
        }

        // POST: VaccineCampingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineCampingTable vaccineCampingTable = db.VaccineCampingTables.Find(id);
            db.VaccineCampingTables.Remove(vaccineCampingTable);
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
