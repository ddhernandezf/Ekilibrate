using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Administracion
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Administracion")]
    public class clsUsuarioPorRolBase : IEntityPOCO<List<Int32>>
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public DateTime TransacDateTime { get; set; }
        [DataMember]
        public string TransacUser { get; set; }

        List<Int32> IEntityPOCO<List<Int32>>.Key
        {
            get
            {
                return new List<Int32> (new Int32[] { IdUsuario, IdRol });
            }
            set
            {
                IdUsuario = value[0];
                IdRol = value[1];
            }
        }
    }
}