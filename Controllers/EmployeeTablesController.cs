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
    public class EmployeeTablesController : Controller
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: EmployeeTables
        public ActionResult Index()
        {
            var employeeTables = db.EmployeeTables.Include(e => e.DepartmentTable).Include(e => e.GenderTable).Include(e => e.HealthOffice);
            return View(employeeTables.ToList());
        }

        // GET: EmployeeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeTable);
        }

        // GET: EmployeeTables/Create
        public ActionResult Create()
        {
            ViewBag.Emp_DepartID = new SelectList(db.DepartmentTables, "Depart_ID", "DepartName");
            ViewBag.Emp_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName");
            ViewBag.Emp_HO_ID = new SelectList(db.HealthOffices, "HO_ID", "HO_OfficeName");
            return View();
        }

        // POST: EmployeeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,EMP_FName,EMP_MiniName,EMP_LName,Emp_GenderID,Emp_Address,Emp_Salary,EMP_PhoneNo,Emp_Email,Emp_DepartID,Emp_Specilization,Emp_Years_Of_Experience,Emp_HO_ID")] EmployeeTable employeeTable)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTables.Add(employeeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Emp_DepartID = new SelectList(db.DepartmentTables, "Depart_ID", "DepartName", employeeTable.Emp_DepartID);
            ViewBag.Emp_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", employeeTable.Emp_GenderID);
            ViewBag.Emp_HO_ID = new SelectList(db.HealthOffices, "HO_ID", "HO_OfficeName", employeeTable.Emp_HO_ID);
            return View(employeeTable);
        }

        // GET: EmployeeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_DepartID = new SelectList(db.DepartmentTables, "Depart_ID", "DepartName", employeeTable.Emp_DepartID);
            ViewBag.Emp_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", employeeTable.Emp_GenderID);
            ViewBag.Emp_HO_ID = new SelectList(db.HealthOffices, "HO_ID", "HO_OfficeName", employeeTable.Emp_HO_ID);
            return View(employeeTable);
        }

        // POST: EmployeeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,EMP_FName,EMP_MiniName,EMP_LName,Emp_GenderID,Emp_Address,Emp_Salary,EMP_PhoneNo,Emp_Email,Emp_DepartID,Emp_Specilization,Emp_Years_Of_Experience,Emp_HO_ID")] EmployeeTable employeeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_DepartID = new SelectList(db.DepartmentTables, "Depart_ID", "DepartName", employeeTable.Emp_DepartID);
            ViewBag.Emp_GenderID = new SelectList(db.GenderTables, "GenderID", "GenderName", employeeTable.Emp_GenderID);
            ViewBag.Emp_HO_ID = new SelectList(db.HealthOffices, "HO_ID", "HO_OfficeName", employeeTable.Emp_HO_ID);
            return View(employeeTable);
        }

        // GET: EmployeeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeTable);
        }

        // POST: EmployeeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            db.EmployeeTables.Remove(employeeTable);
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
