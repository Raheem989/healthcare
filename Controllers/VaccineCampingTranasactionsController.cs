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
    public class VaccineCampingTranasactionsController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: VaccineCampingTranasactions
        public ActionResult Index()
        {
            var vaccineCampingTranasactions = db.VaccineCampingTranasactions.Include(v => v.ChildTable).Include(v => v.EmployeeTable).Include(v => v.VaccineCampingTable);
            return View(vaccineCampingTranasactions.ToList());
        }

        // GET: VaccineCampingTranasactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineCampingTranasaction vaccineCampingTranasaction = db.VaccineCampingTranasactions.Find(id);
            if (vaccineCampingTranasaction == null)
            {
                return HttpNotFound();
            }
            return View(vaccineCampingTranasaction);
        }

        // GET: VaccineCampingTranasactions/Create
        public ActionResult Create()
        {
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName");
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName");
            ViewBag.VC_ID = new SelectList(db.VaccineCampingTables, "VC_ID", "VC_Name");
            return View();
        }

        // POST: VaccineCampingTranasactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CT_ID,Child_ID,Emp_ID,VC_ID,Date")] VaccineCampingTranasaction vaccineCampingTranasaction)
        {
            if (ModelState.IsValid)
            {
                db.VaccineCampingTranasactions.Add(vaccineCampingTranasaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", vaccineCampingTranasaction.Child_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", vaccineCampingTranasaction.Emp_ID);
            ViewBag.VC_ID = new SelectList(db.VaccineCampingTables, "VC_ID", "VC_Name", vaccineCampingTranasaction.VC_ID);
            return View(vaccineCampingTranasaction);
        }

        // GET: VaccineCampingTranasactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineCampingTranasaction vaccineCampingTranasaction = db.VaccineCampingTranasactions.Find(id);
            if (vaccineCampingTranasaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", vaccineCampingTranasaction.Child_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", vaccineCampingTranasaction.Emp_ID);
            ViewBag.VC_ID = new SelectList(db.VaccineCampingTables, "VC_ID", "VC_Name", vaccineCampingTranasaction.VC_ID);
            return View(vaccineCampingTranasaction);
        }

        // POST: VaccineCampingTranasactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CT_ID,Child_ID,Emp_ID,VC_ID,Date")] VaccineCampingTranasaction vaccineCampingTranasaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineCampingTranasaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", vaccineCampingTranasaction.Child_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", vaccineCampingTranasaction.Emp_ID);
            ViewBag.VC_ID = new SelectList(db.VaccineCampingTables, "VC_ID", "VC_Name", vaccineCampingTranasaction.VC_ID);
            return View(vaccineCampingTranasaction);
        }

        // GET: VaccineCampingTranasactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineCampingTranasaction vaccineCampingTranasaction = db.VaccineCampingTranasactions.Find(id);
            if (vaccineCampingTranasaction == null)
            {
                return HttpNotFound();
            }
            return View(vaccineCampingTranasaction);
        }

        // POST: VaccineCampingTranasactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineCampingTranasaction vaccineCampingTranasaction = db.VaccineCampingTranasactions.Find(id);
            db.VaccineCampingTranasactions.Remove(vaccineCampingTranasaction);
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
