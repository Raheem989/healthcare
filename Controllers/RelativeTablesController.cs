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
    public class RelativeTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: RelativeTables
        public ActionResult Index()
        {
            var relativeTables = db.RelativeTables.Include(r => r.AreaTable).Include(r => r.CovernorateTable).Include(r => r.GenderTable).Include(r => r.NeighborhoodTable);
            return View(relativeTables.ToList());
        }

        // GET: RelativeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelativeTable relativeTable = db.RelativeTables.Find(id);
            if (relativeTable == null)
            {
                return HttpNotFound();
            }
            return View(relativeTable);
        }

        // GET: RelativeTables/Create
        public ActionResult Create()
        {
            ViewBag.Re_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName");
            ViewBag.Re_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName");
            ViewBag.Re_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName");
            ViewBag.Re_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName");
            return View();
        }

        // POST: RelativeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Re_ID,Re_FName,Re_MiniName,Re_LName,Re_GenderID,Re_CovernorateID,Re_AreaID,Re_NeighborhoodID,Re_Address,Re_PhoneNo,Re_Email")] RelativeTable relativeTable)
        {
            if (ModelState.IsValid)
            {
                db.RelativeTables.Add(relativeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Re_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", relativeTable.Re_AreaID);
            ViewBag.Re_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", relativeTable.Re_CovernorateID);
            ViewBag.Re_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", relativeTable.Re_GenderID);
            ViewBag.Re_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", relativeTable.Re_NeighborhoodID);
            return View(relativeTable);
        }

        // GET: RelativeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelativeTable relativeTable = db.RelativeTables.Find(id);
            if (relativeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Re_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", relativeTable.Re_AreaID);
            ViewBag.Re_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", relativeTable.Re_CovernorateID);
            ViewBag.Re_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", relativeTable.Re_GenderID);
            ViewBag.Re_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", relativeTable.Re_NeighborhoodID);
            return View(relativeTable);
        }

        // POST: RelativeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Re_ID,Re_FName,Re_MiniName,Re_LName,Re_GenderID,Re_CovernorateID,Re_AreaID,Re_NeighborhoodID,Re_Address,Re_PhoneNo,Re_Email")] RelativeTable relativeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relativeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Re_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", relativeTable.Re_AreaID);
            ViewBag.Re_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", relativeTable.Re_CovernorateID);
            ViewBag.Re_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", relativeTable.Re_GenderID);
            ViewBag.Re_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", relativeTable.Re_NeighborhoodID);
            return View(relativeTable);
        }

        // GET: RelativeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelativeTable relativeTable = db.RelativeTables.Find(id);
            if (relativeTable == null)
            {
                return HttpNotFound();
            }
            return View(relativeTable);
        }

        // POST: RelativeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelativeTable relativeTable = db.RelativeTables.Find(id);
            db.RelativeTables.Remove(relativeTable);
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
