using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class AssesmentDbContext : DbContext
    {
        public AssesmentDbContext() : base("YourDbContextName")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.EmployeeDetails)
        //        .WithOne(ed => ed.Employee)
        //        .HasForeignKey<Employee>(e => e.EmployeeDetailsId);

        //    modelBuilder.Entity<EmployeeDetails>()
        //        .HasOne(ed => ed.Employee)
        //        .WithOne(e => e.EmployeeDetails)
        //        .HasForeignKey<EmployeeDetails>(ed => ed.EmployeeId);
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the relationship between Employee and EmployeeDetails
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.EmployeeDetails) // EmployeeDetails is optional for Employee
                .WithRequired(ed => ed.Employee);    // Employee is required for EmployeeDetails
        }

        
    }
}