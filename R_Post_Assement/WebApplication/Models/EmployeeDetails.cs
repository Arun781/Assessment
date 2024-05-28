using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [NotMapped] // Not stored in the database
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ReEnterPassword { get; set; }

        // Navigation property
        public virtual Employee Employee { get; set; }

        public EmployeeDetails()
        {
        }

        public EmployeeDetails(int iD, string name, string email, string phone, int age, DateTime dOB, string city, string state, string password, string reEnterPassword, Employee employee)
        {
            ID = iD;
            Name = name;
            Email = email;
            Phone = phone;
            Age = age;
            DOB = dOB;
            City = city;
            State = state;
            Password = password;
            ReEnterPassword = reEnterPassword;
            Employee = employee;
        }
    }
}