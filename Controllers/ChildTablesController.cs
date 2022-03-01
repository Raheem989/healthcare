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
    public class ChildTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: ChildTables
        public ActionResult Index()
        {
            var childTables = db.ChildTables.Include(c => c.AreaTable).Include(c => c.CovernorateTable).Include(c => c.GenderTable).Include(c => c.NeighborhoodTable).Include(c => c.RelativeTable);
            return View(childTables.ToList());
        }

        // GET: ChildTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildTable childTable = db.ChildTables.Find(id);
            if (childTable == null)
            {
                return HttpNotFound();
            }
            return View(childTable);
        }

        // GET: ChildTables/Create
        public ActionResult Create()
        {
            ViewBag.Child_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName");
            ViewBag.Child_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName");
            ViewBag.Child_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName");
            ViewBag.Child_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName");
            ViewBag.Re_ID = new SelectList(db.RelativeTables, "Re_ID", "Re_FName");
            return View();
        }

        // POST: ChildTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Child_ID,Child_FName,Child_MiniName,Child_LName,Re_ID,Child_GenderID,Child_BirthDate,Child_CovernorateID,Child_AreaID,Child_NeighborhoodID,Child_Address")] ChildTable childTable)
        {
            if (ModelState.IsValid)
            {
                db.ChildTables.Add(childTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Child_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", childTable.Child_AreaID);
            ViewBag.Child_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", childTable.Child_CovernorateID);
            ViewBag.Child_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", childTable.Child_GenderID);
            ViewBag.Child_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", childTable.Child_NeighborhoodID);
            ViewBag.Re_ID = new SelectList(db.RelativeTables, "Re_ID", "Re_FName", childTable.Re_ID);
            return View(childTable);
        }

        // GET: ChildTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildTable childTable = db.ChildTables.Find(id);
            if (childTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Child_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", childTable.Child_AreaID);
            ViewBag.Child_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", childTable.Child_CovernorateID);
            ViewBag.Child_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", childTable.Child_GenderID);
            ViewBag.Child_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", childTable.Child_NeighborhoodID);
            ViewBag.Re_ID = new SelectList(db.RelativeTables, "Re_ID", "Re_FName", childTable.Re_ID);
            return View(childTable);
        }

        // POST: ChildTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Child_ID,Child_FName,Child_MiniName,Child_LName,Re_ID,Child_GenderID,Child_BirthDate,Child_CovernorateID,Child_AreaID,Child_NeighborhoodID,Child_Address")] ChildTable childTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Child_AreaID = new SelectList(db.AreaTables, "AreaID", "AreaName", childTable.Child_AreaID);
            ViewBag.Child_CovernorateID = new SelectList(db.CovernorateTables, "CovernorateID", "CovernorateName", childTable.Child_CovernorateID);
            ViewBag.Child_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", childTable.Child_GenderID);
            ViewBag.Child_NeighborhoodID = new SelectList(db.NeighborhoodTables, "NeighborhoodID", "NeighborhoodName", childTable.Child_NeighborhoodID);
            ViewBag.Re_ID = new SelectList(db.RelativeTables, "Re_ID", "Re_FName", childTable.Re_ID);
            return View(childTable);
        }

        // GET: ChildTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildTable childTable = db.ChildTables.Find(id);
            if (childTable == null)
            {
                return HttpNotFound();
            }
            return View(childTable);
        }

        // POST: ChildTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChildTable childTable = db.ChildTables.Find(id);
            db.ChildTables.Remove(childTable);
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
