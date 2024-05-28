using L_R_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace L_R_App.Data
{
    public class L_R_AppContext : DbContext
    { 
        public L_R_AppContext() : base("name=L_R_AppContext")
        {
        }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
