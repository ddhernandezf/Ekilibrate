using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioAdministrativoUI.Models
{
    public class ViewModelObjeto
    {

        public int IdPermission { get; set; }

        /// <summary>
        /// Nombre del permiso.
        /// </summary>
        [Display(Name = "Nombre del objeto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre de objeto es un campo requerido.")]
        [StringLength(45, ErrorMessage = "El nombre del objeto no puede tener mas de 45 caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// Descripción del permiso.
        /// </summary>
        [Display(Name = "Descripción del objeto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción de objeto es un campo requerido.")]
        [StringLength(200, ErrorMessage = "La descripción del objeto no puede tener mas de 200 caracteres.")]
        public string Description { get; set; }


        /// <summary>
        /// Producto al que pertenece el permiso.
        /// </summary>
        [Display(Name = "Dueño del permiso")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "El propietario del permiso es un campo requerido.")]
        //[Range(1, int.MaxValue - 1, ErrorMessage = "El valor del propietario debe de ser mayor a 0.")]

        public int IdProduct { get; set; }

        [Display(Name = "Producto")]
        public string ProductName { get; set; }
        public int IdOwner { get; set; }

        /// <summary>
        /// Permiso padre al que pertenece el permiso.
        /// </summary>
        [Display(Name = "Objeto padre")]
        [Range(1, int.MaxValue - 1, ErrorMessage = "El valor del objeto padre debe de ser mayor a 0.")]
        public int? IdPermissionParent { get; set; }

        public int? IdNewPermissionParent { get; set; }
    }
}