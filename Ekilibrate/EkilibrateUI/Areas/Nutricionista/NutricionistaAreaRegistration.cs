using System.Web.Mvc;

namespace EkilibrateUI.Areas.Nutricionista
{
    public class NutricionistaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Nutricionista";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Nutricionista_default",
                "Nutricionista/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}