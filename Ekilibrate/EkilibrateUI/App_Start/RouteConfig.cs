using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EkilibrateUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            ControllerBuilder.Current
                .DefaultNamespaces.Add("EkilibrateUI.Areas.SitioAdministrativo.Controllers");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "EkilibrateUI.Areas.SitioAdministrativo.Controllers" }
            );
        }
    }
}
