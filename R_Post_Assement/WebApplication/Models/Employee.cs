﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebApplication.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Joining date is required")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }

        public Employee()
        {
        }

        public Employee(int iD, string companyName, string role, decimal salary, DateTime joiningDate, string description, DateTime createdAt, ICollection<EmployeeDetails> employeeDetails)
        {
            ID = iD;
            CompanyName = companyName;
            Role = role;
            Salary = salary;
            JoiningDate = joiningDate;
            Description = description;
            CreatedAt = createdAt;
            EmployeeDetails = employeeDetails;
        }
    }
}