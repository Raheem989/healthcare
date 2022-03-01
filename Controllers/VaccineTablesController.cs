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
    public class VaccineTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: VaccineTables
        public ActionResult Index()
        {
            var vaccineTables = db.VaccineTables.Include(v => v.DissessesTable).Include(v => v.VaccineAgeTable).Include(v => v.VaccineNameTable);
            return View(vaccineTables.ToList());
        }

        // GET: VaccineTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineTable vaccineTable = db.VaccineTables.Find(id);
            if (vaccineTable == null)
            {
                return HttpNotFound();
            }
            return View(vaccineTable);
        }

        // GET: VaccineTables/Create
        public ActionResult Create()
        {
            ViewBag.DI_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name");
            ViewBag.VaccineAge_ID = new SelectList(db.VaccineAgeTables, "VaccineAge_ID", "VaccineAgeName");
            ViewBag.VaccineName_ID = new SelectList(db.VaccineNameTables, "VaccineName_ID", "VacineName");
            return View();
        }

        // POST: VaccineTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vacc_ID,VaccineAge_ID,VaccineName_ID,DI_ID,DoseRoute")] VaccineTable vaccineTable)
        {
            if (ModelState.IsValid)
            {
                db.VaccineTables.Add(vaccineTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DI_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name", vaccineTable.DI_ID);
            ViewBag.VaccineAge_ID = new SelectList(db.VaccineAgeTables, "VaccineAge_ID", "VaccineAgeName", vaccineTable.VaccineAge_ID);
            ViewBag.VaccineName_ID = new SelectList(db.VaccineNameTables, "VaccineName_ID", "VacineName", vaccineTable.VaccineName_ID);
            return View(vaccineTable);
        }

        // GET: VaccineTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineTable vaccineTable = db.VaccineTables.Find(id);
            if (vaccineTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DI_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name", vaccineTable.DI_ID);
            ViewBag.VaccineAge_ID = new SelectList(db.VaccineAgeTables, "VaccineAge_ID", "VaccineAgeName", vaccineTable.VaccineAge_ID);
            ViewBag.VaccineName_ID = new SelectList(db.VaccineNameTables, "VaccineName_ID", "VacineName", vaccineTable.VaccineName_ID);
            return View(vaccineTable);
        }

        // POST: VaccineTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vacc_ID,VaccineAge_ID,VaccineName_ID,DI_ID,DoseRoute")] VaccineTable vaccineTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DI_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name", vaccineTable.DI_ID);
            ViewBag.VaccineAge_ID = new SelectList(db.VaccineAgeTables, "VaccineAge_ID", "VaccineAgeName", vaccineTable.VaccineAge_ID);
            ViewBag.VaccineName_ID = new SelectList(db.VaccineNameTables, "VaccineName_ID", "VacineName", vaccineTable.VaccineName_ID);
            return View(vaccineTable);
        }

        // GET: VaccineTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineTable vaccineTable = db.VaccineTables.Find(id);
            if (vaccineTable == null)
            {
                return HttpNotFound();
            }
            return View(vaccineTable);
        }

        // POST: VaccineTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineTable vaccineTable = db.VaccineTables.Find(id);
            db.VaccineTables.Remove(vaccineTable);
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
