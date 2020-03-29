using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.NETMVCDemoProjects.identityDemo.Startup))]
namespace ASP.NETMVCDemoProjects.identityDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
