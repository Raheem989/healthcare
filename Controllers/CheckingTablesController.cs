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
    public class CheckingTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: CheckingTables
        public ActionResult Index()
        {
            var checkingTables = db.CheckingTables.Include(c => c.CheckResTable).Include(c => c.ChildTable).Include(c => c.DissessesTable).Include(c => c.EmployeeTable);
            return View(checkingTables.ToList());
        }

        // GET: CheckingTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckingTable checkingTable = db.CheckingTables.Find(id);
            if (checkingTable == null)
            {
                return HttpNotFound();
            }
            return View(checkingTable);
        }

        // GET: CheckingTables/Create
        public ActionResult Create()
        {
            ViewBag.CheckResult_ID = new SelectList(db.CheckResTables, "CheckingRes_ID", "CheckResName");
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName");
            ViewBag.Di_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name");
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName");
            return View();
        }

        // POST: CheckingTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Checking_ID,Child_ID,Emp_ID,Di_ID,CheckResult_ID,Weight,Height,date")] CheckingTable checkingTable)
        {
            if (ModelState.IsValid)
            {
                db.CheckingTables.Add(checkingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CheckResult_ID = new SelectList(db.CheckResTables, "CheckingRes_ID", "CheckResName", checkingTable.CheckResult_ID);
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", checkingTable.Child_ID);
            ViewBag.Di_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name", checkingTable.Di_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", checkingTable.Emp_ID);
            return View(checkingTable);
        }

        // GET: CheckingTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckingTable checkingTable = db.CheckingTables.Find(id);
            if (checkingTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckResult_ID = new SelectList(db.CheckResTables, "CheckingRes_ID", "CheckResName", checkingTable.CheckResult_ID);
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", checkingTable.Child_ID);
            ViewBag.Di_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name", checkingTable.Di_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", checkingTable.Emp_ID);
            return View(checkingTable);
        }

        // POST: CheckingTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Checking_ID,Child_ID,Emp_ID,Di_ID,CheckResult_ID,Weight,Height,date")] CheckingTable checkingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CheckResult_ID = new SelectList(db.CheckResTables, "CheckingRes_ID", "CheckResName", checkingTable.CheckResult_ID);
            ViewBag.Child_ID = new SelectList(db.ChildTables, "Child_ID", "Child_FName", checkingTable.Child_ID);
            ViewBag.Di_ID = new SelectList(db.DissessesTables, "Di_ID", "Di_Name", checkingTable.Di_ID);
            ViewBag.Emp_ID = new SelectList(db.EmployeeTables, "Emp_ID", "EMP_FName", checkingTable.Emp_ID);
            return View(checkingTable);
        }

        // GET: CheckingTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckingTable checkingTable = db.CheckingTables.Find(id);
            if (checkingTable == null)
            {
                return HttpNotFound();
            }
            return View(checkingTable);
        }

        // POST: CheckingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckingTable checkingTable = db.CheckingTables.Find(id);
            db.CheckingTables.Remove(checkingTable);
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
