﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R_Post_WebApp.Data;
using R_Post_WebApp.Models;

namespace R_Post_WebApp.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private R_Post_WebAppContext db = new R_Post_WebAppContext();

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            return View(db.EmployeeDetails.ToList());
        }

        // GET: EmployeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.EmployeeDetails.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Phone,Age,DOB,City,State,Password")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDetails.Add(employeeDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.EmployeeDetails.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Phone,Age,DOB,City,State,Password")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.EmployeeDetails.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetails employeeDetails = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetails);
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
