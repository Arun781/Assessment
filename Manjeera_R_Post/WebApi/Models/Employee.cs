using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "PinCode is required")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid PinCode. It must be 6 digits.")]
        public string PinCode { get; set; }

        [ForeignKey("EmployeeDetails")]
        public int EmployeeDetailsId { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string name, int age, string email, DateTime dob, string password, string city, string state, string pinCode, int employeeDetailsId, EmployeeDetails employeeDetails)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            Dob = dob;
            Password = password;
            City = city;
            State = state;
            PinCode = pinCode;
            EmployeeDetailsId = employeeDetailsId;
            EmployeeDetails = employeeDetails;
        }
    }
}