using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EmployeeDetails
    {
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Joining Date is required")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedAt { get; set; }


        public Employee Employee { get; set; }

        public EmployeeDetails()
        {
        }

        public EmployeeDetails(int id, string companyName, string role, decimal salary, DateTime joiningDate, string createdBy, DateTime modifiedAt, Employee employee)
        {
            Id = id;
            CompanyName = companyName;
            Role = role;
            Salary = salary;
            JoiningDate = joiningDate;
            CreatedBy = createdBy;
            ModifiedAt = modifiedAt;
            Employee = employee;
        }
    }
}