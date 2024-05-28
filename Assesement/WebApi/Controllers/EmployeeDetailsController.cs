using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeDetailsController : ApiController
    {
        private AssesmentDbContext db = new AssesmentDbContext();

        // GET: api/EmployeeDetails
        public IQueryable<EmployeeDetails> GetEmployeeDetails()
        {
            return db.EmployeeDetails;
        }

        // GET: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetails))]
        public async Task<IHttpActionResult> GetEmployeeDetails(int id)
        {
            EmployeeDetails employeeDetails = await db.EmployeeDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return Ok(employeeDetails);
        }

        // PUT: api/EmployeeDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeDetails(int id, EmployeeDetails employeeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailsExists(id))
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

        // POST: api/EmployeeDetails
        [ResponseType(typeof(EmployeeDetails))]
        public async Task<IHttpActionResult> PostEmployeeDetails(EmployeeDetails employeeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDetails.Add(employeeDetails);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetailsExists(employeeDetails.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeeDetails.Id }, employeeDetails);
        }

        // DELETE: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetails))]
        public async Task<IHttpActionResult> DeleteEmployeeDetails(int id)
        {
            EmployeeDetails employeeDetails = await db.EmployeeDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(employeeDetails);
            await db.SaveChangesAsync();

            return Ok(employeeDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailsExists(int id)
        {
            return db.EmployeeDetails.Count(e => e.Id == id) > 0;
        }
    }
}