using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JRECars.Models;
using System.Data.Entity;
using Data.Migrations;

namespace JRECars
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			Database.SetInitializer<JREMotorsDB>(new AddRoles()); ;

			AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			Database.SetInitializer(new CreateDatabaseIfNotExists<JREMotorsDB>());
			
			

		}
	}
}
