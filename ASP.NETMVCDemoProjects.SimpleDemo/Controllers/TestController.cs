using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;
using ASP.NETMVCDemoProjects.SimpleDemo.ViewModel;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public string GetString()
        {
            return "Hello World is old now.It's time for wassup bro.";
        }

        public class Customer
        {
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public override string ToString()
            {
                return this.CustomerName+"|"+this.Address;
            }
        }

        public Customer getCustomer()
        {
            Customer c=new Customer();
            c.Address = "Address";
            c.CustomerName = "Name";
            return c;
        }

        [NonAction]
        public string Simplemethod()
        {
            return "hi";
        }

        public ActionResult GetView()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
               
                  EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                  List<Employee> employees = empBal.GetEmployees();
               
                  List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
               
                 foreach (Employee emp in employees)
                 {
                     EmployeeViewModel empViewModel = new EmployeeViewModel();
                     empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                     empViewModel.Salary = emp.Salary.ToString("C");
                     if (emp.Salary > 15000)
                      {
                          empViewModel.SalaryColor = "yellow";
                      }
                  else
                  {
                          empViewModel.SalaryColor = "green";
                      }
                     empViewModels.Add(empViewModel);
                 }
                 employeeListViewModel.Employees = empViewModels;
                 employeeListViewModel.UserName = "Admin";
                 return View("MyView", employeeListViewModel);
        }

    }
}