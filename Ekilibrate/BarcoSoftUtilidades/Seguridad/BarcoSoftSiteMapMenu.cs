using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BarcoSoftUtilidades.Seguridad
{

    /// <summary>
    /// A base DynamicSiteMapNode
    /// </summary>
    public class BarcoSoftSiteMapMenu : DynamicNodeProviderBase
    {
        /// <summary>
        /// Gets the dynamic node collection.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            BarcoSoftUtilidades.Seguridad.Usuario s = (BarcoSoftUtilidades.Seguridad.Usuario)HttpContext.Current.Session["actual_Bs_User"];
            if (s == null)
            {
                FormsAuthentication.SignOut();
                return new List<DynamicNode>();
            }
            return ReturnAll(s);
        }

        /// <summary>
        /// Returns all.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DynamicNode> ReturnAll(BarcoSoftUtilidades.Seguridad.Usuario user)
        {
            //Todo: Load From Database

            BarcoSoftUtilidades.Data.BarcoSoftUtilidadesDB db = new BarcoSoftUtilidades.Data.BarcoSoftUtilidadesDB(true);
            var listaRoles = db.UsuarioPorRol.Where(x => x.IdUsuario == user.IdUsuario &&  x.Rol.Activo).Select(y => y.IdRol).ToList();
            var Menus = db.Permiso.Where(x => listaRoles.Where(t => t == x.IdRol && x.Objeto.Activo).Count() > 0);
            List<DynamicNode> nodes = new List<DynamicNode>();
            Menus.ToList().ForEach(x =>
            {
                var menu = x.Objeto.Menu.Where(y => y.Activo).FirstOrDefault();
                if (menu != null)
                {
                    nodes.Add(new DynamicNode
                    {
                        Title = menu.Nombre,
                        ParentKey = menu.Objeto.IdObjetoPadre.ToString(),
                        Key = menu.IdObjeto.ToString(),
                        Controller = menu.TargetController == null ? "d" : menu.TargetController,
                        Action = menu.Target == null ? "d" : menu.Target,
                        //  Area = menu.TargetController == null ? null : menu.TargetController.Split('/').Count() == 0 ? null : menu.TargetController.Split('/')[0],
                        ImageUrl = menu.ImageUrl,

                    });
                }
            });


            nodes.Where(x => nodes.Where(y => y.Key == x.ParentKey).Count() == 0).ToList().ForEach(z => { z.ParentKey = null; });



            return nodes;
        }
    }
}
