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
    public class clsTestFinanzas : IEntityPOCO<List<Int32>>
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int PreguntaId { get; set; }
        [DataMember]
        public int RespuestaId { get; set; }

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
}