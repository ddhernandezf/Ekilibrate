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
    public class clsEmocionBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Int32 ID_ANSIEDAD { get; set; }
        [DataMember]
        public String RESPUESTA { get; set; }

        [DataMember]
        public IEnumerable<clsAnsiedad> LISTA_ANSIEDAD { get; set; }


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
    public sealed class clsEmocion : clsEmocionBase
    {
        public String PARTICIPANTE { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsEmocionFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }

}
