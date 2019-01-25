using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Proyecto
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsCitaProgramacion : IEntityPOCO<Int32>
    {
        [DataMember]
        public int CitaId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public int CitaDiaId { get; set; }
        [DataMember]
        public int CitaHoraId { get; set; }
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
                return CitaId;
            }
            set
            {
                CitaId = value;
            }
        }
    }


}