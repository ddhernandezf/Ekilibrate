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
    public class clsPreguntaLiderazgo : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 PreguntaId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public Boolean Siempre { get; set; }
        [DataMember]
        public Boolean Frecuentemente { get; set; }
        [DataMember]
        public Boolean CasiNunca { get; set; }
        [DataMember]
        public Boolean Nunca { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return PreguntaId;
            }
            set
            {
                PreguntaId = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]

    public sealed class clsPreguntaLiderazgoFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }
}
  

