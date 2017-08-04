﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SchoolManagementSystem.Models;
using System.Data.Entity;

namespace SchoolManagementSystem
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			//Database.SetInitializer(new SchoolDbInitializer());

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
