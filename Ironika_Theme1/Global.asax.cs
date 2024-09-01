using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ironika_Theme1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }
        void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapPageRoute("PostRoutea1", "Order", "~/WebForm1.aspx");

            //routes.MapPageRoute("TicketList", "TicketList", "~/WebForm1.aspx");

            //routes.MapPageRoute("PostRoutea2", "VerifyPage", "~/VerifyPage.aspx");

            //routes.MapPageRoute("PostRoutea3", "Successed", "~/successed.aspx");

            //routes.MapPageRoute("PostRoutea4", "Failed", "~/failed.aspx");

        }
    }
}
