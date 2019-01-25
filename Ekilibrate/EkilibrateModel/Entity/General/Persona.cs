using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.General
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.General")]
    public class clsPersonaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [Display(Name = "Mi Nombre es:")]
        public string Nombre
        {
            get
            {
                if (PrimerNombre != null && PrimerNombre.Trim().Length > 0)
                    return PrimerNombre + ((SegundoNombre != null && SegundoNombre.Trim().Length > 0) ? " " + SegundoNombre : "");
                else
                    return string.Empty;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] nombres = value.Split();
                    PrimerNombre = nombres[0];
                    if (nombres.Length > 1 && nombres[1] != null)
                        SegundoNombre = nombres[1];
                }
            }
        }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [Display(Name = "Mis nombres son:")]
        public string PrimerNombre { get; set; }
        [DataMember]
        [Display(Name = "Mi Segundo Nombre es:")]
        public string SegundoNombre { get; set; }

        [Display(Name = "Mis apellidos son:")]
        public string Apellido
        {
            get
            {

                if (PrimerApellido != null && PrimerApellido.Trim().Length > 0)
                    return PrimerApellido.Trim() + ((SegundoApellido != null && SegundoApellido.Trim().Length > 0) ? " " + SegundoApellido.Trim() : "");
                else
                    return string.Empty;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] apellidos = value.Split();
                    PrimerApellido = apellidos[0];
                    if (apellidos.Length > 1 && apellidos[1] != null)
                        SegundoApellido = apellidos[1];
                }
            }
        }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el apellido")]
        [Display(Name = "Mi Apellido es:")]
        public string PrimerApellido { get; set; }
        [DataMember]
        [Display(Name = "Mi Segundo Apellido es:")]
        public string SegundoApellido { get; set; }
        [Display(Name = "Apellido de Casada:")]
        public string ApellidoCasada { get; set; }
        [Display(Name = "Mi Nombre es:")]
        public string NombreCompleto
        {
            get
            {
                if (PrimerNombre != null && PrimerNombre.Trim().Length > 0)
                    return PrimerNombre + ((SegundoNombre != null && SegundoNombre.Trim().Length > 0) ? " " + SegundoNombre : "") + (string.IsNullOrEmpty(PrimerApellido) ? "" : " " + PrimerApellido) + (string.IsNullOrEmpty(SegundoApellido) ? "" : " " + SegundoApellido) + (string.IsNullOrEmpty(ApellidoCasada) ? " de " : " " + ApellidoCasada);
                else
                    return string.Empty;
            }
            set
            {
            }
        }
        [DataMember]
        [Display(Name = "Código de País")]
        public string TelPais
        {
            get
            {
                if (Telefono != null && Telefono.Trim().Length > 0)
                    return Telefono.Substring(0, 4);
                else
                    return "+502";
            }
            set
            {
                if (value != null && value.Length > 0)
                    Telefono = TelPais + " " + value;
                else
                    Telefono = String.Empty;
            }
        }
        [DataMember]
        [Display(Name = "Número de Teléfono")]
        public string TelNumero
        {
            get
            {
                if (Telefono != null && Telefono.Trim().Length > 0)
                    return Telefono.Substring(5, Telefono.Trim().Length-5);
                else
                    return string.Empty;
            }
            set
            {
                if (value != null && value.Length > 0)
                    Telefono = TelPais + " " + value;
                else
                    Telefono = String.Empty;

            }
        }
        [DataMember]
        [Display(Name = "Mi Teléfono de oficina (Cód. País + No. Teléfono): ")]
        public string Telefono { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Debe ingresar el correo del participante")]
        [Display(Name = "Mi Correo electrónico:")]
        public string Correo { get; set; }
        [DataMember]
        [Display(Name = "Ext.")]
        public string Extension { get; set; }
        [DataMember]
        [Display(Name = "Puesto que Desempeño:")]
        public string Puesto { get; set; }
        [DataMember]
        [Display(Name = "Departamento:")]
        public string Departamento { get; set; }
        [DataMember]
        [Display(Name = "Mi teléfono móvil (Cód. País + No. Teléfono):")]
        public string Celular { get; set; }
        [DataMember]
        [Display(Name = "Código de País")]
        public string CelPais
        {
            get
            {
                if (Celular != null && Celular.Trim().Length > 0)
                    return Celular.Substring(0, 4);
                else
                    return "+502";
            }
            set
            {
                if (value != null && value.Length > 0)
                    Celular = CelPais + " " + value;
                else
                    Celular = String.Empty;
            }
        }
        [DataMember]
        [Display(Name = "Número de Teléfono")]
        public string CelNumero
        {
            get
            {
                if (Celular != null && Celular.Trim().Length > 0)
                    return Celular.Substring(5, Celular.Trim().Length - 5);
                else
                    return string.Empty;
            }
            set
            {
                if (value != null && value.Length > 0)
                    Celular = CelPais + " " + value;
                else
                    Celular = String.Empty;

            }
        }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
    }
}
