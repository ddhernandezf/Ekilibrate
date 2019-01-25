using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkilibrateUI.Areas.SitioAdministrativo.Models
{
    public class LoginViewModel
    {

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Password { get; set; }


        public string returnUrl { get; set; }


    }

    public class ChangePasswordViewModel
    {
        public string NombreUsuario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma contraseña nueva")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string ConfirmNewPassword { get; set; }

    }


    public class RecoverPasswordViewModel
    {
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma contraseña nueva")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string ConfirmNewPassword { get; set; }

    }


    public class ForgotMyPasswordViewModel
    {

        [Display(Name = "Nombre de usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Recuperar por email")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; }

        

        
    }

    public class EncryptUtility
    {

        /// <summary>
        /// Cadena encriptada
        /// </summary>
        [Display(Name = "Cadena encriptada")]
        public string EncryptString { get; set; }

        /// <summary>
        /// cadena desencriptada
        /// </summary>
        [Display(Name = "Resultado desencripción")]
        public string ValueDecript { get; set; }


        [Display(Name = "Cadena a encriptar")]
        public string DecryptString { get; set; }

        /// <summary>
        /// cadena desencriptada
        /// </summary>
        [Display(Name = "Resultado encripción")]
        public string ValueEncript { get; set; }
    }
}