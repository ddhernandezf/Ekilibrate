using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsExpedienteManejoEmociones
    {

        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public int RiesgoEnfermedadEstress { get; set; }
        
        [DataMember]
        public string ObservacionesAnsiedad { get; set; }

    }
}
