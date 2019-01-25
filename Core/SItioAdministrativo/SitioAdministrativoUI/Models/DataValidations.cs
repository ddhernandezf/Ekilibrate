using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SitioAdministrativoUI.Models.Data
{
    #region Usuario
    [MetadataType(typeof(UsuarioMetaData))]
    public partial class Usuario
    { }

    public partial class UsuarioMetaData
    {

        [Required(ErrorMessage = "El nombre de usuario es un campo requerido")]
        [Display(Name = "Nombre de usuario")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es un campo requerido")]
        [Display(Name = "Tipo de usuario")]
        [Range(1, int.MaxValue, ErrorMessage = "El tipo de usuario es un campo requerido")]
        public int IdTipoUsuario { get; set; }
    }
    #endregion

    #region Persona
    [MetadataType(typeof(PersonaMetaData))]
    public partial class Persona
    { }

    public partial class PersonaMetaData
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombres")]
        [MaxLength(75, ErrorMessage = "El campo no puede tener mas de 75 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es un campo requerido")]
        [Display(Name = "Apellidos")]
        [MaxLength(75, ErrorMessage = "El campo no puede tener mas de 75 caracteres.")]
        public string Apellidos { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefono invalido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El email es un campo requerido")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Direccion de correo invalida (example@outlook.com).")]
        [EmailAddress(ErrorMessage = "Direccion de correo invalida (example@outlook.com).")]
        [MaxLength(360, ErrorMessage = "El campo no puede tener mas de 360 caracteres.")]
        public string Email { get; set; }


    }
    #endregion

    #region TipoUsuario
    [MetadataType(typeof(TipoUsuarioMetaData))]
    public partial class TipoUsuario
    { }

    public partial class TipoUsuarioMetaData
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
        [Url(ErrorMessage = "La url no es valida")]
        public string UrlRedireccion { get; set; }
    }
    #endregion

    #region Rol
    [MetadataType(typeof(RolMetaData))]
    public partial class Rol
    { }

    public partial class RolMetaData
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
    }

    #endregion

    #region Propietario
    [MetadataType(typeof(PropietarioMetaData))]
    public partial class Propietario
    { }

    public partial class PropietarioMetaData
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Descripción es un campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string Descripcion { get; set; }

    }
    #endregion

    #region Producto
    [MetadataType(typeof(ProductoMetaData))]
    public partial class Producto
    { }

    public partial class ProductoMetaData
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

    }
    #endregion

    #region Objeto
    [MetadataType(typeof(ObjetoMetaData))]
    public partial class Objeto
    { }

    public partial class ObjetoMetaData
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Descripción es un campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener mas de 100 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El producto es un campo requerido")]
        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "El producto es un campo requerido")]
        public int IdProducto { get; set; }

    }
    #endregion


    #region ParametroGeneral
    public enum EParametroTipo
    {
        String = 1,
        Entero = 2,
        Decimal = 3,
        Booleano = 4,
        FechaHora = 5,
        Hora = 6,
        EncryptString = 7,
    }

    [MetadataType(typeof(ParametroGeneralMetaData))]
    public partial class ParametroGeneral
    { }

    public partial class ParametroGeneralMetaData
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

    }
    #endregion

    #region Menu
    [MetadataType(typeof(MenuMetaData))]
    public partial class Menu
    { }

    public partial class MenuMetaData
    {

        [Required(ErrorMessage = "El nombre es un campo requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener mas de 45 caracteres.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El objeto es un campo requerido")]
        [Display(Name = "Objeto")]
        [Range(1, int.MaxValue, ErrorMessage = "El, objeto es un campo requerido")]
        public int IdObjeto { get; set; }



        [Required(ErrorMessage = "El tipo es un campo requerido")]
        [Display(Name = "Tipo Menu")]
        [Range(1, int.MaxValue, ErrorMessage = "El tipo de menu es un campo requerido")]
        public int IdMenuTipo { get; set; }

 
        [Display(Name = "Target Action")]
        [MaxLength(300, ErrorMessage = "El target no puede tener mas de 300 caracteres.")]
        public string Target { get; set; }


        [Display(Name = "Target Controller")]
        [MaxLength(300, ErrorMessage = "El target no puede tener mas de 300 caracteres.")]
        public string TargetController { get; set; }

    }
    #endregion




}