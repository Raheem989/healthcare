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
    public class HealthOfficesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: HealthOffices
        public ActionResult Index()
        {
            var healthOffices = db.HealthOffices.Include(h => h.AreaTable).Include(h => h.CovernorateTable).Include(h => h.MinistryRepresentator).Include(h => h.NeighborhoodTable);
            return View(healthOffices.ToList());
        }

        // GET: HealthOffices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthOffice healthOffice = db.HealthOffices.Find(id);
            if (healthOffice == null)
            {
                return HttpNotFound();
            }
            return View(healthOffice);
        }

        // GET: HealthOffices/Create
        public ActionResult Create()
        {
            ViewBag.HO_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName");
            ViewBag.HO_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName");
            ViewBag.MR_ID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName");
            ViewBag.HO_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName");
            return View();
        }

        // POST: HealthOffices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HO_ID,HO_CovernorateID,HO_AreaID,HO_NeighborhoodID,HO_OfficeName,HO_Address,HO_Email,HO_PhoneNo,MR_ID")] HealthOffice healthOffice)
        {
            if (ModelState.IsValid)
            {
                db.HealthOffices.Add(healthOffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HO_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", healthOffice.HO_AreaID);
            ViewBag.HO_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", healthOffice.HO_CovernorateID);
            ViewBag.MR_ID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName", healthOffice.MR_ID);
            ViewBag.HO_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", healthOffice.HO_NeighborhoodID);
            return View(healthOffice);
        }

        // GET: HealthOffices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthOffice healthOffice = db.HealthOffices.Find(id);
            if (healthOffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.HO_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", healthOffice.HO_AreaID);
            ViewBag.HO_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", healthOffice.HO_CovernorateID);
            ViewBag.MR_ID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName", healthOffice.MR_ID);
            ViewBag.HO_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", healthOffice.HO_NeighborhoodID);
            return View(healthOffice);
        }

        // POST: HealthOffices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HO_ID,HO_CovernorateID,HO_AreaID,HO_NeighborhoodID,HO_OfficeName,HO_Address,HO_Email,HO_PhoneNo,MR_ID")] HealthOffice healthOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthOffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HO_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", healthOffice.HO_AreaID);
            ViewBag.HO_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", healthOffice.HO_CovernorateID);
            ViewBag.MR_ID = new SelectList(db.MinistryRepresentators, "MR_ID", "MR_FName", healthOffice.MR_ID);
            ViewBag.HO_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", healthOffice.HO_NeighborhoodID);
            return View(healthOffice);
        }

        // GET: HealthOffices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthOffice healthOffice = db.HealthOffices.Find(id);
            if (healthOffice == null)
            {
                return HttpNotFound();
            }
            return View(healthOffice);
        }

        // POST: HealthOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthOffice healthOffice = db.HealthOffices.Find(id);
            db.HealthOffices.Remove(healthOffice);
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
