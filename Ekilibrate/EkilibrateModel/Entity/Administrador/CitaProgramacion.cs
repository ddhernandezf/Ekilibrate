using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Administrador
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administrador")]
    public class clsCitaProgramacion : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public bool Cancelada { get; set; }
        [DataMember]
        public DateTime? FechaInicio { get; set; }
        [DataMember]
        public DateTime? FechaFin { get; set; }
        
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

    public class clsCitaProgramacionHora : clsCitaProgramacion
    {
        [DataMember]
        public int HoraInicio { get; set; }
        [DataMember]
        public int MinutoFinal { get; set; }

    }
}