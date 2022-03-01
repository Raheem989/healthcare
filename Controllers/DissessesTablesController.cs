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
    public class DissessesTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: DissessesTables
        public ActionResult Index()
        {
            var dissessesTables = db.DissessesTables.Include(d => d.VaccineTable);
            return View(dissessesTables.ToList());
        }

        // GET: DissessesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DissessesTable dissessesTable = db.DissessesTables.Find(id);
            if (dissessesTable == null)
            {
                return HttpNotFound();
            }
            return View(dissessesTable);
        }

        // GET: DissessesTables/Create
        public ActionResult Create()
        {
            
            ViewBag.Vaccine_ID = new SelectList(db.VaccineTables, "Vacc_ID", "VaccineName_ID");
            ViewBag.VaccineName_ID = new SelectList(db.VaccineNameTables, "VaccineName_ID", "VacineName");
            return View();
        }

        // POST: DissessesTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Di_ID,Di_Name,DI_SideEffect,Vaccine_ID")] DissessesTable dissessesTable)
        {
            if (ModelState.IsValid)
            {
                db.DissessesTables.Add(dissessesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.Vaccine_ID = new SelectList(db.VaccineTables, "Vacc_ID", "VaccineName_ID", dissessesTable.Vaccine_ID);
            ViewBag.VaccineName_ID = new SelectList(db.VaccineNameTables, "VaccineName_ID", "VacineName");
            return View(dissessesTable);
        }

        // GET: DissessesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DissessesTable dissessesTable = db.DissessesTables.Find(id);
            if (dissessesTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vaccine_ID = new SelectList(db.VaccineTables, "Vacc_ID", "DoseRoute", dissessesTable.Vaccine_ID);
            return View(dissessesTable);
        }

        // POST: DissessesTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Di_ID,Di_Name,DI_SideEffect,Vaccine_ID")] DissessesTable dissessesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dissessesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vaccine_ID = new SelectList(db.VaccineTables, "Vacc_ID", "DoseRoute", dissessesTable.Vaccine_ID);
            return View(dissessesTable);
        }

        // GET: DissessesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DissessesTable dissessesTable = db.DissessesTables.Find(id);
            if (dissessesTable == null)
            {
                return HttpNotFound();
            }
            return View(dissessesTable);
        }

        // POST: DissessesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DissessesTable dissessesTable = db.DissessesTables.Find(id);
            db.DissessesTables.Remove(dissessesTable);
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
