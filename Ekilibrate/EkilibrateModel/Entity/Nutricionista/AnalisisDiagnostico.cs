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
    public class AnalisisDiagnostico : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public string PrincipalProblema { get; set; }
        [DataMember]
        public string PlanDeAccion { get; set; }
        [DataMember]
        public string Recomendaciones { get; set; }
        [DataMember]
        public string HabitosEstablecer { get; set; }
        [DataMember]
        public string PlanDeAlimentacion { get; set; }

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
}