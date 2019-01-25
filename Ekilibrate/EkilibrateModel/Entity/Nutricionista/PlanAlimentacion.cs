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
    public class clsPlanAlimentacionBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public string Desayuno { get; set; }
        [DataMember]
        public string RefaccionAm { get; set; }
        [DataMember]
        public string Almuerzo { get; set; }
        [DataMember]
        public string RefaccionPm { get; set; }
        [DataMember]
        public string Cena { get; set; }
        [DataMember]
        public int Cereales { get; set; }
        [DataMember]
        public int Lacteos { get; set; }
        [DataMember]
        public int LacteosDescremados { get; set; }
        [DataMember]
        public int LacteosSemi { get; set; }
        [DataMember]
        public int Frutas { get; set; }
        [DataMember]
        public int Vegetales { get; set; }
        [DataMember]
        public int Azucares { get; set; }
        [DataMember]
        public int Carnes { get; set; }
        [DataMember]
        public int Grasas { get; set; }
        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return CitaId;
            }
            set
            {
                CitaId = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public sealed class clsPlanAlimentacion : clsPlanAlimentacionBase
    {
        [DataMember]
        public int RED { get; set; }

        [DataMember]
        public bool Nuevo { get; set; }

        [DataMember]
        public bool ReadOnly { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class clsTest : IEntityPOCO<Int32>
    {
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int ParticipanteId { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return CitaId;
            }
            set
            {
                CitaId = value;
            }
        }
    }
}