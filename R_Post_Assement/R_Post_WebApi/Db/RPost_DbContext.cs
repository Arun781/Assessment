using R_Post_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace R_Post_WebApi.Db
{
    public class RPost_DbContext : DbContext
    {
        protected RPost_DbContext() : base("FollowingTheDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Employee> DataSet { get; set; }
        public DbSet<EmployeeDetails> DataSetDetails { get; set; }
    }
}