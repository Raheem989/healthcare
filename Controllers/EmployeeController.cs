using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinalProjectKidsHealthCenter.Models;

namespace FinalProjectKidsHealthCenter.Controllers
{
    public class EmployeeController : ApiController
    {
        private KidsCenterDataContext db = new KidsCenterDataContext();

        // GET: api/Employee
        public IQueryable<EmployeeTable> GetEmployeeTables()
        {
            return db.EmployeeTables;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(EmployeeTable))]
        public IHttpActionResult GetEmployeeTable(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return NotFound();
            }

            return Ok(employeeTable);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeTable(int id, EmployeeTable employeeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeTable.Emp_ID)
            {
                return BadRequest();
            }

            db.Entry(employeeTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee
        [ResponseType(typeof(EmployeeTable))]
        public IHttpActionResult PostEmployeeTable(EmployeeTable employeeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeTables.Add(employeeTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeeTable.Emp_ID }, employeeTable);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(EmployeeTable))]
        public IHttpActionResult DeleteEmployeeTable(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return NotFound();
            }

            db.EmployeeTables.Remove(employeeTable);
            db.SaveChanges();

            return Ok(employeeTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeTableExists(int id)
        {
            return db.EmployeeTables.Count(e => e.Emp_ID == id) > 0;
        }
    }
}