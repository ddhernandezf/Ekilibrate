using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Nutricionista
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public class clsCalificacionTaller : IEntityPOCO<Int32>
    {
        [DataMember]
        public int NoSesion { get; set; }
        [DataMember]
        public int AreaId { get; set; }

        [DataMember]
        public string Nombre { get; set; }


        [DataMember]
        public int IdTaller { get; set; }


        [DataMember]
        public double Asistencia { get; set; }

        [DataMember]
        public double Tarea{ get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return NoSesion;
            }
            set
            {
                NoSesion = value;
            }
        }
    }


    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public sealed class clsCalificacionTallerFiltro : clsPaging
    {
        [DataMember]
        public int ParticipanteId { get; set; }

        [DataMember]
        public int TallerId { get; set; }
    }
}
