using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NETMVCDemoProjects.SimpleDemo.Filters;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;
using ASP.NETMVCDemoProjects.SimpleDemo.ViewModel;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class EmployeeController : Controller
    {
        [HeaderFooterFilter]
        [Authorize]
        // GET: Test
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.FooterData = new FooterViewModel();
            employeeListViewModel.FooterData.CompanyName = "StepByStep";
            employeeListViewModel.FooterData.CompanyName = DateTime.Now.ToString();
            //employeeListViewModel.UserName = User.Identity.Name; //New Line
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
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
            //employeeListViewModel.FooterData = new FooterViewModel();
            //employeeListViewModel.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
            //employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();
            employeeListViewModel.UserName = User.Identity.Name; //New Line
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
        [HeaderFooterFilter]
        [AdminFilter]
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
                        vm.FooterData = new FooterViewModel();
                        vm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
                        vm.FooterData.Year = DateTime.Now.Year.ToString();
                        vm.UserName = User.Identity.Name; //New Line
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