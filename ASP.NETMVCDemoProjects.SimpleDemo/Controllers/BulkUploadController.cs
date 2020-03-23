using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASP.NETMVCDemoProjects.SimpleDemo.Filters;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;
using ASP.NETMVCDemoProjects.SimpleDemo.ViewModel;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class BulkUploadController:AsyncController
    {
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }
        [AdminFilter]
        [HandleError]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            int t1 = Thread.CurrentThread.ManagedThreadId;
            Console.Out.WriteLine(t1);
            List<Employee> employees =await Task.Factory.StartNew<List<Employee>>(()=> GetEmployees(model)) ;
            int t2 = Thread.CurrentThread.ManagedThreadId;
            Console.Out.WriteLine(t2);
            EmployeeBusinessLayer bal=new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            var employees=new List<Employee>();
            StreamReader streamReader=new StreamReader(model.fileUpload.InputStream);
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var vaues = line.Split(',');
                Employee e=new Employee();
                e.FirstName = vaues[0];
                e.LastName = vaues[1];
                e.Salary = int.Parse(vaues[2]);
                employees.Add(e);
            }

            return employees;
        }
    }
}