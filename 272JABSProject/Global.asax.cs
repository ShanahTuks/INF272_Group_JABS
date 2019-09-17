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
            "~/Views/{1}/{0}.cshtml", "~/Views/{1}/{0}.vbhtml",
            "~/Views/Common/{0}.cshtml", "~/Views/Common/{0}.vbhtml"
        };

            MasterLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml", "~/Views/{1}/{0}.vbhtml",
            "~/Views/Common/{0}.cshtml", "~/Views/Common/{0}.vbhtml"
        };

            PartialViewLocationFormats = new[]
            {
            "~/Views/{1}/{0}.cshtml", "~/Views/{1}/{0}.vbhtml",
            "~/Views/Common/{0}.cshtml", "~/Views/Common/{0}.vbhtml"
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

            ViewEngines.Engines.Clear();
            var viewEngine = new CustomViewLocationRazorViewEngine();
            ViewEngines.Engines.Add(viewEngine);
        }
    }
}
