using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace EkilibrateUI.Areas.SitioAdministrativo
{
    public class SitioAdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SitioAdministrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SitioAdministrativo_default",
                "SitioAdministrativo/{controller}/{action}/{id}",
                new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                new[] { "EkilibrateUI.Areas.SitioAdministrativo.Controllers" }
            );
        }
    }

    public enum Accesos
    {
        Generales = 4, //Objeto padre de opciones generales del sistema
        Productos = 5, //Productos del sistema
        Propietarios = 6, //Propietarios del sistema
        Seguridad = 7, //Objeto padre de las opciones de seguridad del sistema.
        Roles = 8, //Administración de roles
        Objetos = 9, //Administración de objetos
        Encripción = 10, //Herramienta de encripción
        Cuentas = 11, //Objeto padre para la administración de cuentas del sistema
        Usuarios = 12, //Administración de usuarios
        Tipo_de_usuarios = 13, //Administración de tipo de usuarios
        Parametros = 14, //Administración de parametros Generales
    }

    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public JsonSerializerSettings Settings { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;

            var scriptSerializer = JsonSerializer.Create(this.Settings);

            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, this.Data);
                response.Write(sw.ToString());
            }
        }
    }
}