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
using R_Post_WebApi.Data;
using R_Post_WebApi.Models;

namespace R_Post_WebApi.Controllers
{
    public class EmployeeDetailsController : ApiController
    {
        private R_Post_WebApiContext db = new R_Post_WebApiContext();

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

            if (id != employeeDetails.ID)
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
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeDetails.ID }, employeeDetails);
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
            return db.EmployeeDetails.Count(e => e.ID == id) > 0;
        }
    }
}