using Ekilibrate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsExpedienteCrecimientoPersonal

    {

        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public int FactorLiderazgo { get; set; }



        [DataMember]
        public string FactorFinanzas{ get; set; }

        [DataMember]
        public string ObservacionesLiderazgo { get; set; }


        [DataMember]
        public string ObservacionesFinanzas { get; set; }

    }

    public sealed class clsExpedienteFiltro: clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }

     
}
