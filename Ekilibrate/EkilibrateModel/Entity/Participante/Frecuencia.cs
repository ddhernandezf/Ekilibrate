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
    public class clsFrecuenciaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Int32 ID_PREGUNTA { get; set; }
        [DataMember]
        public Boolean SIEMPRE { get; set; }
        [DataMember]
        public Boolean FRECUENTE { get; set; }
        [DataMember]
        public Boolean CASI_NUNCA { get; set; }
        [DataMember]
        public Boolean NUNCA { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ID_PREGUNTA;
            }
            set
            {
                ID_PREGUNTA = value;
            }
        }
    }
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsFrecuencia : clsFrecuenciaBase
    {
        [DataMember]
        public string PREGUNTA { get; set; }
    }
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]

    public sealed class clsFrecuenciaFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }

   
}

