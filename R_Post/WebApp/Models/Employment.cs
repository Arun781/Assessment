using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Employment
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Joining date is required")]
        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        // Foreign key property
        [ForeignKey("Person")]
        public int PersonID { get; set; }

        // Navigation property to access the related person
        public virtual Person Person { get; set; }
    }
}