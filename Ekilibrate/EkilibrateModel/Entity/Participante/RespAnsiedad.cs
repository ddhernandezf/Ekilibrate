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
    public class clsRespAnsiedadBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_ANSIEDAD { get; set; }
        [DataMember]
        public String ANSIEDAD { get; set; }


        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ID_ANSIEDAD;
            }
            set
            {
                ID_ANSIEDAD = value;
            }
        }
    }
}
