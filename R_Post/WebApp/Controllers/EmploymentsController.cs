using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmploymentsController : Controller
    {
        private WebApiContext db = new WebApiContext();

        // GET: Employments
        public async Task<ActionResult> Index()
        {
            var employments = db.Employments.Include(e => e.Person);
            return View(await employments.ToListAsync());
        }

        // GET: Employments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // GET: Employments/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name");
            return View();
        }

        // POST: Employments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Company,Role,Salary,JoiningDate,OrderDate,PersonID")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                db.Employments.Add(employment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", employment.PersonID);
            return View(employment);
        }

        // GET: Employments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", employment.PersonID);
            return View(employment);
        }

        // POST: Employments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Company,Role,Salary,JoiningDate,OrderDate,PersonID")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "ID", "Name", employment.PersonID);
            return View(employment);
        }

        // GET: Employments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // POST: Employments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employment employment = await db.Employments.FindAsync(id);
            db.Employments.Remove(employment);
            await db.SaveChangesAsync();
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
