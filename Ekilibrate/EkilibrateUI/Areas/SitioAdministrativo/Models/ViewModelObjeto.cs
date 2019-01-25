using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkilibrateUI.Areas.SitioAdministrativo.Models
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

    public class ViewModelTipoUsuario
    {
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Descripción es un campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El url es un campo requerido")]
        [Display(Name = "Url de redirección")]
        [MaxLength(300, ErrorMessage = "El campo no puede tener mas de 300 caracteres.")]

        public string UrlRedireccion { get; set; }

        public int IdTipoUsuario { get; set; }
      
        public bool Activo { get; set; }
    }


    public class ViewModelRole
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Descripción es un campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El propietario es un campo requerido")]
        [Display(Name = "Propietario")]
        [Range(1, int.MaxValue, ErrorMessage = "El propietario es un campo requerido")]
        public int IdPropietario { get; set; }

        public int IdRol { get; set; }

        public bool Activo { get; set; }
    }

    public class ViewModelParametroGeneral
    {
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El valor es un campo requerido")]
        [Display(Name = "Valor")]
        [MaxLength(1000, ErrorMessage = "El campo no puede tener mas de 1000 caracteres.")]
        public string Valor { get; set; }


        [Required(ErrorMessage = "El propietario es un campo requerido")]
        [Display(Name = "Propietario")]
        [Range(1, int.MaxValue, ErrorMessage = "El propietario es un campo requerido")]
        public int IdPropietario { get; set; }

        
        public int IdParametroGeneral { get; set; }

        [Required(ErrorMessage = "El tipo de parámetro es un campo requerido")]
        [Display(Name = "Tipo parámetro")]
        [Range(1, int.MaxValue, ErrorMessage = "El tipo de parámetro es un campo requerido")]
        public int IdParametroTipo { get; set; }
        public bool Activo { get; set; }
        public System.DateTime TransacDateTime { get; set; }
        public string TransacUser { get; set; }
    }

    public class ViewModelUsuario
    {
        [Required(ErrorMessage = "El nombre de usuario es un campo requerido")]
        [Display(Name = "Nombre de usuario")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es un campo requerido")]
        [Display(Name = "Tipo de usuario")]
        [Range(1, int.MaxValue, ErrorMessage = "El tipo de usuario es un campo requerido")]
        public int IdTipoUsuario { get; set; }

        public int IdUsuario { get; set; }
        public string Contraseña { get; set; }
        public int IdPersona { get; set; }
        public bool Activo { get; set; }

        public ViewModelPersona GE_Persona { get; set; }


    }

    public class ViewModelPropietario
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Descripción es un campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string Descripcion { get; set; }

        public int IdPropietario { get; set; }
        public bool Activo { get; set; }


    }
    public class ViewModelProducto
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Descripción es un campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El propietario es un campo requerido")]
        [Display(Name = "Propietario")]
        [Range(1, int.MaxValue, ErrorMessage = "El propietario es un campo requerido")]
        public int IdPropietario { get; set; }

        public int IdProducto { get; set; }

        public bool Activo { get; set; }
    }

    public class ViewModelPersona
    {
        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombres")]
        [MaxLength(150, ErrorMessage = "El campo no puede tener mas de 150 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es un campo requerido")]
        [Display(Name = "Apellidos")]
        [MaxLength(150, ErrorMessage = "El campo no puede tener mas de 150 caracteres.")]
        public string Apellido { get; set; }


        [Display(Name = "Teléfono")]
        [MaxLength(10, ErrorMessage = "El campo no puede tener mas de 10 caracteres.")]
        [Required(ErrorMessage = "El teléfono es un campo requerido")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefono invalido")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es un campo requerido")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El email es un campo requerido")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Direccion de correo invalida (example@outlook.com).")]
        [EmailAddress(ErrorMessage = "Direccion de correo invalida (example@outlook.com).")]
        [MaxLength(360, ErrorMessage = "El campo no puede tener mas de 360 caracteres.")]
        public string Correo { get; set; }


        [Display(Name = "Extensión")]
        [MaxLength(8, ErrorMessage = "El campo no puede tener mas de 8 caracteres.")]
        public string Extension { get; set; }

        [Display(Name = "Puesto")]
        [MaxLength(250, ErrorMessage = "El campo no puede tener mas de 250 caracteres.")]
        public string Puesto { get; set; }

        public int Id { get; set; }

        public byte[] FotoPerfil { get; set; }


    }
}