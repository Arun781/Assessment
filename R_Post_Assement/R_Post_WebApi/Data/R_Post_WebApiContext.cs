﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R_Post_WebApi.Data
{
    public class R_Post_WebApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public R_Post_WebApiContext() : base("name=R_Post_WebApiContext")
        {
        }

        public System.Data.Entity.DbSet<R_Post_WebApi.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<R_Post_WebApi.Models.EmployeeDetails> EmployeeDetails { get; set; }
    }
}