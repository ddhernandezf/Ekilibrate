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
    public class clsAsertivaBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Int32 ID_PREGUNTA { get; set; }
        [DataMember]
        public Boolean EN_ABSOLUTO { get; set; }
        [DataMember]
        public Boolean UN_POCO { get; set; }
        [DataMember]
        public Boolean BASTANTE { get; set; }
        [DataMember]
        public Boolean MUCHO { get; set; }
        [DataMember]
        public Boolean MUCHISIMO { get; set; }
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
    public sealed class clsAsertiva : clsAsertivaBase
    {
        [DataMember]
        public String PREGUNTA { get; set; }
    }
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]

    public sealed class clsAsertivaFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }
}
  

