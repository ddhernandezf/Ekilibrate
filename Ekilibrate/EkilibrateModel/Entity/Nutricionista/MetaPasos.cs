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
    public class clsMetaPasoBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public int IdPaso { get; set; }

        [DataMember]
        public int Semana { get; set; }

        [DataMember]
        public int Meta { get; set; }

        [DataMember]
        public int ParticipanteId { get; set; }
        
        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return IdPaso;
            }
            set
            {
                IdPaso = value;
            }
        }
    }


    [DataContract(Namespace = "Ekilibrate.Model.Entity.Nutricionista")]
    public sealed class clsMetaPasosFiltro : clsPaging
    {
        [DataMember]
        public int ParticipanteId { get; set; }
    }
}
