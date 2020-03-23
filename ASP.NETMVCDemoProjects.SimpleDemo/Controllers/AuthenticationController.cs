using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASP.NETMVCDemoProjects.SimpleDemo.Models;
using ASP.NETMVCDemoProjects.SimpleDemo.ViewModel;

namespace ASP.NETMVCDemoProjects.SimpleDemo.Controllers
{
    public class AuthenticationController : Controller
    {

        // GET: Authentication
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DoLogin(UserDetails user)
        {

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer dal = new EmployeeBusinessLayer();
                UserStatus status = dal.IsVaildUser(user);
                bool IsAdmin = false;
                if (status == UserStatus.AuthenticatedAdmin)
                {
                    IsAdmin = true;
                }else if (status==UserStatus.NonAuthenticatedUser)
                {
                    IsAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
                FormsAuthentication.SetAuthCookie(user.UserName,false);
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}