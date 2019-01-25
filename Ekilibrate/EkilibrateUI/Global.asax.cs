using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EkilibrateUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CultureInfo threadCultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            CultureInfo uiCultureInfo = (CultureInfo)CultureInfo.CurrentUICulture.Clone();

            threadCultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            threadCultureInfo.DateTimeFormat.LongDatePattern = "dd/MM/yyyy hh:mm:ss tt";
            uiCultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            uiCultureInfo.DateTimeFormat.LongDatePattern = "dd/MM/yyyy hh:mm:ss tt";

            Thread.CurrentThread.CurrentCulture = threadCultureInfo;
            Thread.CurrentThread.CurrentUICulture = uiCultureInfo;
        }

#if !DEBUG
        protected void Application_BeginRequest()
        {
            if (!Context.Request.IsSecureConnection)
                Response.Redirect(Context.Request.Url.ToString().Replace("http:", "https:"));
        }
#endif
    }

}
