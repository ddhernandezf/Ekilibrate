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
    public class clsSeguimientoAspectosBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int CitaId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El aspecto es un campo requerido.")]
        [Display(Name = "Aspecto")]
        public int AspectoId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El logro es un campo requerido.")]
        [Display(Name = "Logro")]
        public decimal Logro { get; set; }
        [DataMember]
        [Required(ErrorMessage = "La meta es un campo requerido.")]
        [Display(Name = "Nueva Meta")]
        public decimal Meta { get; set; }
        [DataMember]
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

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
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public sealed class clsSeguimientoAspectos : clsSeguimientoAspectosBase
    {
        [DataMember]
        [Required(ErrorMessage = "El aspecto es un campo requerido.")]
        [Display(Name = "Aspecto")]
        public string Aspecto { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        [Display(Name = "Diagnostico")]
        public decimal Diagnostico { get; set; }

        [DataMember]
        [Display(Name = "Base")]
        public decimal Base { get; set; }

        [DataMember]
        public bool Nuevo { get; set; }

        [DataMember]
        public decimal Porcentaje { get; set; }

        //[DataMember]
        //public decimal Porcentaje {
        //    get {
        //        if (Meta != null && Logro != null && Meta > 0)
        //            return Math.Round(Logro / Meta, 4) * 100;
        //        else
        //            return 0;
        //    }
        //    set {

        //    }
        //}

        [DataMember]
        [Display(Name = "CitaAnterior")]
        public int CitaAnterior { get; set; }

        [DataMember]
        [Display(Name = "Avance")]
        public decimal LogroAnterior { get; set; }

        [DataMember]
        [Display(Name = "Meta")]
        public decimal MetaAnterior { get; set; }

        [DataMember]
        [Display(Name = "ObservacionesAnterior")]
        public string ObservacionesAnterior { get; set; }

        [DataMember]
        [Display(Name = "Logro1")]
        public decimal Logro1 { get; set; }

        [DataMember]
        [Display(Name = "Meta1")]
        public decimal Meta1 { get; set; }

        [DataMember]
        [Display(Name = "Logro2")]
        public decimal Logro2 { get; set; }

        [DataMember]
        [Display(Name = "Meta2")]
        public decimal Meta2 { get; set; }

        [DataMember]
        [Display(Name = "Logro3")]
        public decimal Logro3 { get; set; }

        [DataMember]
        [Display(Name = "Meta3")]
        public decimal Meta3 { get; set; }

        [DataMember]
        [Display(Name = "Logro4")]
        public decimal Logro4 { get; set; }

        [DataMember]
        [Display(Name = "Meta4")]
        public decimal Meta4 { get; set; }

        [DataMember]
        [Display(Name = "Logro5")]
        public decimal Logro5 { get; set; }

        [DataMember]
        [Display(Name = "Meta5")]
        public decimal Meta5 { get; set; }

        [DataMember]
        [Display(Name = "Logro6")]
        public decimal Logro6 { get; set; }

        
        [DataMember]
        [Display(Name = "Meta6")]
        public decimal Meta6 { get; set; }

        [DataMember]
        [Display(Name = "Logro7")]
        public decimal Logro7 { get; set; }

        [DataMember]
        [Display(Name = "Meta7")]
        public decimal Meta7 { get; set; }

        [DataMember]
        [Display(Name = "Logro8")]
        public decimal Logro8 { get; set; }

        [DataMember]
        [Display(Name = "Meta8")]
        public decimal Meta8 { get; set; }

        [DataMember]
        [Display(Name = "Logro9")]
        public decimal Logro9 { get; set; }

        [DataMember]
        [Display(Name = "Meta9")]
        public decimal Meta9 { get; set; }
        
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public sealed class clsSeguimientoAspectosFiltro : clsPaging
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int CitaId { get; set; }
    }
}