using System.Web.Mvc;

namespace EkilibrateUI.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
               "MobileLogin",
               "Api/{controller}/{action}/{UserName}/{Password}",
               new { action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}