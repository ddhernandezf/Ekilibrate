using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BarcoSoftUtilidades;
using System.Web.Security;

namespace BarcoSoftUtilidades.Seguridad
{
    public class BarcoSoftAuthorize : AuthorizeAttribute
    {

        /// <summary>
        /// Identificador del permiso del sistema katharsis.
        /// </summary>
        public int Objeto { get; set; }

        private Usuario user;

        /// <summary>
        /// Método que realiza la validación de la autorización de accesos.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            user = httpContext.GetActualUser();
            return user != null && (Objeto == new int() || UserHasAccess(user, Objeto));
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (user == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                Parametro AccessDenied = new Parametro(Parametro.Enumerable.PáginaAccesodenegadoString);
                filterContext.Result = new RedirectResult(AccessDenied.Valor);
            }
        }


        public static bool UserHasAccess(Usuario user, int objeto)
        {
            try
            {
                Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
                var listaRoles = db.UsuarioPorRol.Where(x => x.IdUsuario == user.IdUsuario && x.Rol.Activo).Select(y => y.IdRol).ToList();
                return db.Permiso.Where(x => x.IdObjeto == objeto && listaRoles.Where(t => t == x.IdRol).Count() > 0).Count() > 0;
            }
            catch
            {
                return false;
            }
        }


        
        public static void LogIn(HttpContextBase httpContext, string pEncryptPassword, string pUserName)
        {
            Data.BarcoSoftUtilidadesDB db = new Data.BarcoSoftUtilidadesDB(true);
            Data.Usuario dbResult;


            dbResult = db.Usuario.Where(x => x.NombreUsuario.ToLower() == pUserName.ToLower()).FirstOrDefault();
            if (dbResult == null)
            {
                throw new Exception("Usuario o password incorrecto");
            }
            else
            {
                if (dbResult.Activo)
                { 
                    if (dbResult.Contraseña != pEncryptPassword)
                    {
                        throw new Exception("Usuario o password incorrecto");
                    }
                    else
                    {
                        httpContext.SetActualUser(pUserName);
                        MvcSiteMapProvider.SiteMaps.ReleaseSiteMap();
                    }
                }
                else
                    throw new Exception("Usuario inactivo, contacta a tu administrador para más información");
            }
        }
    }
}
