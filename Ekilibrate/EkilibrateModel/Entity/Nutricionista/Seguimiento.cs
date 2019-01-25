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
    public class clsSeguimientoBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        [Required(ErrorMessage = "El comentario es un campo requerido.")]
        [Display(Name = "Acuerdos")]
        public string ComentariosRelevantes { get; set; }

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
    public sealed class clsSeguimiento : clsSeguimientoBase
    {
        [DataMember]
        public IEnumerable<clsSeguimientoAspectosBase> Aspectos { get; set; }

        [DataMember]
        public bool Nuevo { get; set; }

        [DataMember]
        public bool ReadOnly { get; set; }

        [DataMember]
        public int No { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public sealed class clsSeguimientoFiltro : clsPaging
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int CitaId { get; set; }
    }


}