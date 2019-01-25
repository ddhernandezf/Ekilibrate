using Kendo.Mvc;
using MvcSiteMapProvider;
using Newtonsoft.Json;
using SitioAdministrativoUI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BarcoSoftUtilidades;
namespace SitioAdministrativoUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);




            if (!SiteMapManager.SiteMaps.ContainsKey("Mvc"))
            {
                SiteMapManager.SiteMaps.Register<XmlSiteMap>("Mvc", sitmap => sitmap.LoadFrom("~/Mvc.sitemap"));
            }

        }
    }

    public enum Accesos
    {
        Roles = 1,
        Seguridad = 3,
        Objetos = 4,
        Encripción = 5,
        Administración_Usuarios = 6,
        Usuarios = 7,
        Tipos_de_usuario = 8,
        General = 9,
        Propietarios = 10,
        Productos = 11,
    }



}

