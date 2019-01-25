using SitioAdministrativoUI.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioAdministrativoUI.Models
{
    public class PermisoObjeto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El identificador del rol es un campo requerido.")]
        [Range(1, int.MaxValue - 1, ErrorMessage = "El valor debe de ser mayor a 0.")]
        public int IdRol { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El identificador del objeto es un campo requerido.")]
        [Range(1, int.MaxValue - 1, ErrorMessage = "El valor debe de ser mayor a 0.")]
        public int IdObjeto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdPermissionParent { get; set; }

        public bool TieneAcceso { get; set; }


        #region Métodos

        /// <summary>
        /// Obtener listado de todos los permisos filtrado por producto. 
        /// </summary>
        /// <param name="pIdRole">Identificador del rol</param>
        /// <param name="pIdProduct">Identificador del producto</param>
        /// <returns></returns>
        public List<PermisoObjeto> Get(int pIdRole, int pIdProduct)
        {
            List<PermisoObjeto> result = null;
            BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);

            result = (from objeto in db.Objeto
                      join permiso in db.Permiso on objeto.IdObjeto equals permiso.IdObjeto into gj
                      from permisoObjeto in gj.DefaultIfEmpty()
                      where objeto.IdProducto == pIdProduct && objeto.Activo
                      select new PermisoObjeto
               {
                   Descripcion = objeto.Descripcion,
                   TieneAcceso = !(permisoObjeto == null),
                   IdObjeto = objeto.IdObjeto,
                   IdPermissionParent = objeto.IdObjetoPadre,
                   IdRol = pIdRole,
                   Nombre = objeto.Nombre
               }).ToList();
            return result;
        }


        /// <summary>
        /// Agregar una relación de un permiso con un rol.
        /// </summary>
        /// <param name="IdPermission">Identificador del permiso</param>
        /// <param name="IdRole">Identificador del rol</param>
        /// <param name="UserTransac">Usuario realiza la transacción</param>
        public void Add(int IdObjeto, int IdRol, string UserTransac)
        {

            BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
            if (IdObjeto  > 0 && IdRol > 0 && UserTransac.Length > 0)
            {
                db.SP_PermisoAObjeto_Ins(IdObjeto, IdRol, UserTransac);
            }
            else
            {
                throw new Exception("Error en en los identificadores.");
            }


        }

        /// <summary>
        /// Elimina una relación de un permiso con un rol.
        /// </summary>
        /// <param name="IdPermission">Identificador del permiso</param>
        /// <param name="IdRole">Identificador del rol</param>
        /// <param name="UserTransac">Usuario realiza la transacción</param>
        public void Delete(int IdObjeto, int IdRol, string UserTransac)
        {
            
                BarcoSoftDBEntities db = new BarcoSoftDBEntities(true);
                if (IdObjeto > 0 && IdRol > 0 && UserTransac.Length > 0)
                {
                    db.SP_PermisoAObjeto_Del(IdObjeto, IdRol, UserTransac);
                }
                else
                {
                    throw new Exception("Error en en los identificadores.");
                }
           
        }
        #endregion

    }
}