using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsDiagnosticoBase : Ekilibrate.Model.Entity.General.clsPersonaBase, IValidatableObject
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        [Display(Name = "Pueden encontrarme en Facebook como ")]
        public String FACEBOOK
        {
            get;
            set;
        }
        [DataMember]
        [Display(Name = "El medio por el que prefieren que me contacten es")]
        [Required(ErrorMessage = "Debes especificar el medio de comunicación en el cual prefieres que te contactemos.")]
        public Int32 ID_MEDIO_COMUNICACION { get; set; }
        [DataMember]
        [Display(Name = "Mi Género es:")]
        public String SEXO { get; set; }
        [DataMember]
        [Display(Name = "Mi Fecha de Nacimiento es: ")]
        [Required(ErrorMessage = "Debe ingresar la fecha de nacimiento del participante")]
        public DateTime FECHA_NACIMIENTO { get; set; }
        [DataMember]
        public Boolean MUJER_EMBARAZADA { get; set; }
        [DataMember]
        [Display(Name = "Fecha de tu última menstruación: ")]
        public DateTime? FEC_ULT_MENSTRUACION { get; set; }
        [DataMember]
        [Display(Name = "Edad gestacional(Semanas): ")]
        [Range(0, int.MaxValue)]
        public Int32? EDAD_GESTACIONAL { get; set; }
        [DataMember]
        [Range(0, int.MaxValue)]
        [Display(Name = "Peso antes del embarazo: ")]
        public Int32? PESO_ANTERIOR { get; set; }
        [DataMember]        
        public Boolean MUJER_LACTANCIA { get; set; }
        [DataMember]
        [Display(Name = "Fecha de Nacimiento del bebé: ")]
        public DateTime? FEC_NAC_BEBE { get; set; }
        [DataMember]
        [Range(0, int.MaxValue)]
        [Display(Name = "Edad Actual (Meses): ")]
        public Int32? EDAD { get; set; }
        [DataMember]
        [Display(Name = "¿Ha presentado algún síntoma de menopausia?")]
        public Boolean MENOPAUSIA { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FEC_ULT_MENSTRUACION.HasValue)
            {
                int EdadGestacional = DateTime.Now.Subtract((DateTime)FEC_ULT_MENSTRUACION).Days / 7;
                if (EdadGestacional > 40 || EdadGestacional < 1)
                    yield return new ValidationResult("La edad gestacional no es congruente, revisa la fecha de tu última menstruación.", new List<string>() { "FEC_ULT_MENSTRUACION" });
            }

            if (ID_MEDIO_COMUNICACION == 3 && (string.IsNullOrEmpty(FACEBOOK) || FACEBOOK.Equals("facebook.com/")))
                yield return new ValidationResult("Debes ingresar tu usuario de facebook.", new List<string>() { "FACEBOOK" });

            if (ID_MEDIO_COMUNICACION == 2 && string.IsNullOrEmpty(Celular))
                yield return new ValidationResult("Debes ingresar tu teléfono móvil.", new List<string>() { "Celular" });
        }
    }
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsDiagnostico : clsDiagnosticoBase
    {
        public String Giro { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsDiagnosticoFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public String NOMBRE { get; set; }
    }
}
