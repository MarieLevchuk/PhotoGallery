using Ninject.Modules;
using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using PhotoGallery.Web.Util;
using Ninject.Web.Mvc;

namespace PhotoGallery.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
                       
            NinjectModule registrationsModule = new NinjectRegistrations();
            NinjectModule serviceModule = new ServiceModule("GalleryContext");
            var kernel = new StandardKernel(registrationsModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
