using SampleCreateJobsQuartz.Jobs;
using SampleCreateJobsQuartz.Jobs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleCreateJobsQuartz
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BaseExecuteJobs<DemoJob>.StartJobDaily("demo Job", "trigger demo", 13, 00).GetAwaiter();
            BaseExecuteJobs<DemoJob>.StartHourlyJob("Hourly Job", "Hourly Trigger ", 1).GetAwaiter();
        }
    }
}
