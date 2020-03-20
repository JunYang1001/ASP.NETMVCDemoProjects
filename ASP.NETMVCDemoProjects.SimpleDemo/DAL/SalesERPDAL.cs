using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;

namespace ASP.NETMVCDemoProjects.SimpleDemo.DAL
{
    public class SalesERPDAL:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
}