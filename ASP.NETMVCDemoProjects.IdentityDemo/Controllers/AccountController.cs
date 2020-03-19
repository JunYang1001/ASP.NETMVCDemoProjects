using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASP.NETMVCDemoProjects.IdentityDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ASP.NETMVCDemoProjects.IdentityDemo.Controllers
{
    public class AccountController : Controller
    {
        private AppUserManger Usermanger
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManger>(); }
        }
        // GET: Account
        public ActionResult Index()
        {
            return View(Usermanger.Users);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser {UserName = model.Name, Email = model.Email};
                IdentityResult result = await Usermanger.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                AddErrorsFromResult(result);
            }

            return View(model);
        }
          private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
