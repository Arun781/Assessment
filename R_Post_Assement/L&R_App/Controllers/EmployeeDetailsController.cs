﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using L_R_App.Data;
using L_R_App.Models;

namespace L_R_App.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private L_R_AppContext db = new L_R_AppContext();

        // POST: /User/Login
        [HttpPost, ActionName("Login")]
        public ActionResult Login(string name, string password)
        {
            // Find the user by name and password
            EmployeeDetails user = db.EmployeeDetails.FirstOrDefault(u => u.Name == name && u.Password == password);

            if (user != null)
            {
                // Successful login
                // You can store user information in session, cookie, or use authentication mechanisms like ASP.NET Identity.
                return RedirectToAction("Index", "EmployeeDetails"); // Redirect to home page or any other desired page upon successful login
            }
            else
            {
                // Failed login
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
           
        }
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
