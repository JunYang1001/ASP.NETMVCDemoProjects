using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NETMVCDemoProjects.SimpleDemo.DAL;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public UserStatus IsVaildUser(UserDetails u)
        {
            if (u.UserName == "admin" && u.Password == "123456")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "user" && u.Password == "123456")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
    }
}