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
    public class clsCitaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int No { get; set; }
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int ProyectoId { get; set; }
        [DataMember]
        public DateTime FechaProgramada { get; set; }
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

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsCita : clsCitaBase
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string Hora { get; set; }
        [DataMember]
        public int TipoCitaId { get; set; }
        [DataMember]
        public int ProgramacionId { get; set; }
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public bool Cancelada { get; set; }
        
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsCitaFiltro
    {
        [DataMember]
        public int NutricionistaId { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
    }
}