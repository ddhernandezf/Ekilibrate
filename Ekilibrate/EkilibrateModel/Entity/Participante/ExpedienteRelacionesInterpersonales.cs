using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsExpedienteRelacionesInterpersonales
    {

        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public int FactorAdministracionTiempo { get; set; }

        [DataMember]
        public string ManejoTiempoTexto { get; set; }

        [DataMember]
        public string ManejoTiempoColor { get; set; }

        [DataMember]
        public string ManejoTiempoRecomendacion { get; set; }


        [DataMember]
        public string FactorComunicacionAsertiva { get; set; }

        [DataMember]
        public string ComunicacionAsertivaTexto { get; set; }

        [DataMember]
        public string ComunicacionAsertivaColor { get; set; }

        [DataMember]
        public string ComunicacionAsertivaRecomendacion { get; set; }

        [DataMember]
        public string ObservacionesManejoTiempo { get; set; }




        [DataMember]
        public string ObservacionesComunicacionAsertiva { get; set; }
    }
}
