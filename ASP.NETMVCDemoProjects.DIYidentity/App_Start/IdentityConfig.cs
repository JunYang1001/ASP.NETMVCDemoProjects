using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NETMVCDemoProjects.DIYidentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ASP.NETMVCDemoProjects.DIYidentity.App_Start
{
    public class ApplicationUsermanger : UserManager<ApplicationUser>
    {
        public ApplicationUsermanger(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static ApplicationUsermanger Create(IdentityFactoryOptions<ApplicationUsermanger> options, IOwinContext context)
        {
            var manager=new ApplicationUsermanger(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            manager.UserValidator=new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            manager.PasswordValidator=new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            return manager;
        }
    }


    
}