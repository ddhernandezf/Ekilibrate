using System.Web.Mvc;

namespace EkilibrateUI.Areas.Administrador
{
    public class AdministradorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrador";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrador_default",
                "Administrador/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public enum Accesos
    {
        Empresas = 1, //Mantenimiento de Empresas 
        Proyectos = 2, //Mantenimiento de proyectos 
        Colaboradores = 3, //Mantenimiento de Colaboradores 
    }
}