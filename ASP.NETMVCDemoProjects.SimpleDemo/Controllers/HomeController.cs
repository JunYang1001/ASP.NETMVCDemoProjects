using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page."+User.Identity.Name;
            
            return View();
        }

        public ActionResult Contact(int? id)
        {
            ViewBag.Message = "Your contact page."+Convert.ToString(id);

            return View();
        }
    }
}