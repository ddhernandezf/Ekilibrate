using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Catalogos
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Catalogos")]
    public class clsAlimentoBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public Int32 GrupoAlimentoId { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
    }


    [DataContract(Namespace = "Ekilibrate.Model.Entity.Catalogos")]
    public sealed class clsAlimento : clsAlimentoBase
    {
        [DataMember]
        public String GrupoAlimento { get; set; }
    }
}
