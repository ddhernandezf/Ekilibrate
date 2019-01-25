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
    public class DiagnosticoAnamnesis : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public int GrupoAlimentoId { get; set; }
        [DataMember]
        public int TiempoComidaId { get; set; }
        [DataMember]
        public int Porciones { get; set; }

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

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class DiagnosticoItem : DiagnosticoAnamnesis
    {
        [DataMember]
        public string NombreColumna { get; set; }
    }


    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class DiagnosticoAnamnesisTiempo : DiagnosticoAnamnesis
    {
        [DataMember]
        public string TiempoComida { get; set; }
        [DataMember]
        public string NombreColumna { get; set; }
        [DataMember]
        public int Lacteos_Enteros { get; set; }
        [DataMember]
        public int Cereales { get; set; }
        [DataMember]
        public int Vegetales { get; set; }
        [DataMember]
        public int Frutas { get; set; }
        [DataMember]
        public int Carnes { get; set; }
        [DataMember]
        public int Grasas { get; set; }
        [DataMember]
        public int Azucares { get; set; }
        [DataMember]
        public int Lacteos_Semi_descremados { get; set; }
        [DataMember]
        public int Lacteos_Descremados { get; set; }

        
    }
}