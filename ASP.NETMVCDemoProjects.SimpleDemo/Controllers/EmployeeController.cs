using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;
using ASP.NETMVCDemoProjects.SimpleDemo.ViewModel;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString();
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

            return View("Index", employeeListViewModel);

        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
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
                return this.CustomerName + "|" + this.Address;
            }
        }

        public Customer getCustomer()
        {
            Customer c = new Customer();
            c.Address = "Address";
            c.CustomerName = "Name";
            return c;
        }

        [NonAction]
        public string Simplemethod()
        {
            return "hi";
        }



    }
}