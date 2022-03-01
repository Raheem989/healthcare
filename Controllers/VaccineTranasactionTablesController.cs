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
    public class VaccineTranasactionTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: VaccineTranasactionTables
        public ActionResult Index()
        {
            var vaccineTranasactionTables = db.VaccineTranasactionTables.Include(v => v.ChildTable).Include(v => v.EmployeeTable).Include(v => v.VaccineTable);
            return View(vaccineTranasactionTables.ToList());
        }

        // GET: VaccineTranasactionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineTranasactionTable vaccineTranasactionTable = db.VaccineTranasactionTables.Find(id);
            if (vaccineTranasactionTable == null)
            {
                return HttpNotFound();
            }
            return View(vaccineTranasactionTable);
        }

        // GET: VaccineTranasactionTables/Create
        public ActionResult Create()
        {
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName");
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName");
            ViewBag.Vacc_ID = new SelectList(db.VaccineTables, "Vacc_ID", "DoseRoute");
            return View();
        }

        // POST: VaccineTranasactionTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VT_ID,Child_ID,Emp_ID,Vacc_ID,Date,DueDate")] VaccineTranasactionTable vaccineTranasactionTable)
        {
            if (ModelState.IsValid)
            {
                db.VaccineTranasactionTables.Add(vaccineTranasactionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", vaccineTranasactionTable.Child_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", vaccineTranasactionTable.Emp_ID);
            ViewBag.Vacc_ID = new SelectList(db.VaccineTables, "Vacc_ID", "DoseRoute", vaccineTranasactionTable.Vacc_ID);
            return View(vaccineTranasactionTable);
        }

        // GET: VaccineTranasactionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineTranasactionTable vaccineTranasactionTable = db.VaccineTranasactionTables.Find(id);
            if (vaccineTranasactionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", vaccineTranasactionTable.Child_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", vaccineTranasactionTable.Emp_ID);
            ViewBag.Vacc_ID = new SelectList(db.VaccineTables, "Vacc_ID", "DoseRoute", vaccineTranasactionTable.Vacc_ID);
            return View(vaccineTranasactionTable);
        }

        // POST: VaccineTranasactionTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VT_ID,Child_ID,Emp_ID,Vacc_ID,Date,DueDate")] VaccineTranasactionTable vaccineTranasactionTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineTranasactionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", vaccineTranasactionTable.Child_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", vaccineTranasactionTable.Emp_ID);
            ViewBag.Vacc_ID = new SelectList(db.VaccineTables, "Vacc_ID", "DoseRoute", vaccineTranasactionTable.Vacc_ID);
            return View(vaccineTranasactionTable);
        }

        // GET: VaccineTranasactionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineTranasactionTable vaccineTranasactionTable = db.VaccineTranasactionTables.Find(id);
            if (vaccineTranasactionTable == null)
            {
                return HttpNotFound();
            }
            return View(vaccineTranasactionTable);
        }

        // POST: VaccineTranasactionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineTranasactionTable vaccineTranasactionTable = db.VaccineTranasactionTables.Find(id);
            db.VaccineTranasactionTables.Remove(vaccineTranasactionTable);
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
