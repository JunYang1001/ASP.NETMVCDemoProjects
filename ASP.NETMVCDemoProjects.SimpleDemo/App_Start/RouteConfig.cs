using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ASP.NETMVCDemoProjects.SimpleDemo.Infrastructure;

namespace ASP.NETMVCDemoProjects.SimpleDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new { UserAgentConstraint = new UserAgentConstraint("Chrome") }
            );
           
        }
    }
}
