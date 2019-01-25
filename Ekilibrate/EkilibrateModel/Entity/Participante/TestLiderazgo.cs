using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsTestLiderazgoBase : IEntityPOCO<List<Int32>>
    {
        [DataMember]
        public Int32 ParticipanteId { get; set; }
        [DataMember]
        public Int32 PreguntaId { get; set; }
        [DataMember]
        public Boolean Siempre { get; set; }
        [DataMember]
        public Boolean Frecuentemente { get; set; }
        [DataMember]
        public Boolean CasiNunca { get; set; }
        [DataMember]
        public Boolean Nunca { get; set; }

        List<Int32> IEntityPOCO<List<Int32>>.Key
        {
            get
            {
                return new List<Int32>(new Int32[] { ParticipanteId, PreguntaId });
            }
            set
            {
                ParticipanteId = value[0];
                PreguntaId = value[1];
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsLiderazgo : clsTestLiderazgoBase
    {
        public String PARTICIPANTE { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]

    public sealed class clsLiderazgoFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }

}
