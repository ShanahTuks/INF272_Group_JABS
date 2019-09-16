using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _272JABSProject
{


    public class CustomViewLocationRazorViewEngine : RazorViewEngine
    {
        public CustomViewLocationRazorViewEngine()
        {
            ViewLocationFormats = new[]
            {
            "~/RazorViews/{1}/{0}.cshtml", "~/RazorViews/{1}/{0}.vbhtml",
            "~/RazorViews/Common/{0}.cshtml", "~/RazorViews/Common/{0}.vbhtml"
        };

            MasterLocationFormats = new[]
            {
            "~/RazorViews/{1}/{0}.cshtml", "~/RazorViews/{1}/{0}.vbhtml",
            "~/RazorViews/Common/{0}.cshtml", "~/RazorViews/Common/{0}.vbhtml"
        };

            PartialViewLocationFormats = new[]
            {
            "~/RazorViews/{1}/{0}.cshtml", "~/RazorViews/{1}/{0}.vbhtml",
            "~/RazorViews/Common/{0}.cshtml", "~/RazorViews/Common/{0}.vbhtml"
        };
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
