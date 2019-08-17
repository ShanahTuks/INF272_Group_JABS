using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_272JABSProject.Startup))]
namespace _272JABSProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
