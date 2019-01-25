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
    public class clsComunicacionBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Int32 ID_PREGUNTA { get; set; }
        [DataMember]
        public String EN_ABSOLUTO { get; set; }
        [DataMember]
        public String UN_POCO { get; set; }
        [DataMember]
        public String BASTANTE { get; set; }
        [DataMember]
        public String MUCHO { get; set; }
        [DataMember]
        public String MUCHISIMO { get; set; }

        [DataMember]
        public IEnumerable<clsAsertiva> LISTA_PREGUNTA_UNO { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ID_PARTICIPANTE;
            }
            set
            {
                ID_PARTICIPANTE = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsComunicacion : clsComunicacionBase
    {
        public String PARTICIPANTE { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsComunicacionFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }

}
