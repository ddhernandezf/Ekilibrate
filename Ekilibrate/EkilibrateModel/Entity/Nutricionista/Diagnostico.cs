using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;
namespace Ekilibrate.Model.Entity.Nutricionista
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class Diagnostico : IEntityPOCO<Int32>, IValidatableObject
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        [Display(Name = "Peso (lbs)")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes ingresar el peso del participante")]
        [Required(ErrorMessage = "Debes ingresar el peso del participante.")]
        public decimal? Peso { get; set; }
        [DataMember]
        [Display(Name = "Estatura (cms.)")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes ingresar la estatura del participante.")]
        [Required(ErrorMessage = "Debes ingresar la estatura del participante.")]
        public decimal? Estatura { get; set; }
        [DataMember]
        [Display(Name = "Circunferencia de muñeca (cms.)")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes ingresar la circunferencia de muñeca.")]
        [Required(ErrorMessage = "Debes ingresar la circunferencia de muñeca.")]
        public decimal? CircunferenciaMuneca { get; set; }
        [DataMember]
        [Display(Name = "Circunferencia abdominal (cms.)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar la circunferencia abdominal.")]
        //[Required(ErrorMessage = "Debes ingresar la circunferencia abdominal.")]
        public decimal? CircunferenciaAbdominal { get; set; }
        [DataMember]
        [Display(Name = "Circunferencia de cadera (cms.)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar la circunferencia de cadera.")]
        public decimal? CircunferenciaCadera { get; set; }
        [DataMember]
        [Display(Name = "Porcetaje de Grasa (%)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar el porcentaje de grasa.")]
        //[Required(ErrorMessage = "Debes ingresar el porcentaje de grasa.")]
        public decimal? PorcentajeGrasa { get; set; }
        [DataMember]
        [Display(Name = "Resultado colesterol (mg/dl)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar el resultado de colesterol.")]
        //[Required(ErrorMessage = "Debes ingresar el resultado de colesterol.")]
        public decimal? Colesterol { get; set; }
        [DataMember]
        [Display(Name = "Resultado Trigliceridos (mg/dl)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar el resultado de trigliceridos.")]
        //[Required(ErrorMessage = "Debes ingresar el resultado de trigliceridos.")]
        public decimal? Triglicerios { get; set; }
        [DataMember]
        [Display(Name = "Resultado glucosa (mg/dl)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar el resultado de glucosa.")]
        //[Required(ErrorMessage = "Debes ingresar el resultado de glucosa.")]
        public decimal? Glucosa { get; set; }
        [DataMember]
        [Display(Name = "Presión Arterial (mmHg)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar la presión arterial del participante.")]
        //[Required(ErrorMessage = "Debes ingresar la presión arterial del participante.")]
        public decimal? PresionArterial { get; set; }
        [DataMember]
        [Display(Name = "Presión Arterial (mmHg)")]
        //[Range(1, int.MaxValue, ErrorMessage = "Debes ingresar la presión arterial del participante.")]
        //[Required(ErrorMessage = "Debes ingresar la presión arterial del participante.")]
        public decimal? PresionArterial2 { get; set; }
        [DataMember]
        [Display(Name = "Sobre el consumo dietético")]
        //[Required(ErrorMessage = "Debes ingresar observaciones.")]
        //[DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }
        [DataMember]        
        [Display(Name = "Sobre la activida física")]
        public string ComentariosRelevantes { get; set; }
        [DataMember]
        [Display(Name = "Género")]
        [Required(ErrorMessage = "Debes ingresar género.")]
        public string Genero { get; set; }
        [DataMember]
        [Display(Name = "Nivel de Actvidad")]
        [Required(ErrorMessage = "Debes ingresar el nivel de actividad.")]
        public string NivelActividad { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ParticipanteId;
            }
            set
            {
                ParticipanteId = value;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!PorcentajeGrasa.HasValue && !CircunferenciaAbdominal.HasValue)
                yield return new ValidationResult("Debes ingresar el porcentaje de grasa o la circunferencia abdominal.", new List<string>() { "PorcentajeGrasa", "CircunferenciaAbdominal" });
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class DiagnosticoAlimentoAnamnesis : Diagnostico
    {

        [DataMember]
        public List<DiagnosticoAlimentos> Alimentacion { get; set; }
        [DataMember]
        public List<DiagnosticoAnamnesis> Anamnesis { get; set; }

    }
    
    

    
}