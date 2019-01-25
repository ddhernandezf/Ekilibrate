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
    public class clsTestTemaFinanzas : IEntityPOCO<List<Int32>>
    {
        [DataMember]
        public int ParticipanteId { get; set; }
        [DataMember]
        public int TemaId { get; set; }

        [DataMember]
        public bool Seleccionado { get; set; }

        [DataMember]
        public string Nombre { get; set; }
        
        List<Int32> IEntityPOCO<List<Int32>>.Key
        {
            get
            {
                return new List<Int32>(new Int32[] { ParticipanteId, TemaId });
            }
            set
            {
                ParticipanteId = value[0];
                TemaId = value[1];
            }
        }
    }
}