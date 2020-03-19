using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP.NETMVCDemoProjects.IdentityDemo.Models
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext():base("IdentityDb")
        {
            
        }

        static AppIdentityDbContext()
        {
            System.Data.Entity.Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }

        public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
        {
            protected override void Seed(AppIdentityDbContext context)
            {
                PerformInitialSetup(context);
                base.Seed(context);
            }

            private void PerformInitialSetup(AppIdentityDbContext context)
            {
                
            }
        }
    }
}