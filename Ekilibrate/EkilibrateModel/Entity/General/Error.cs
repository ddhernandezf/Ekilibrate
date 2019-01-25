using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.General
{
    [DataContract(Namespace = "Ekilibrate.Model.General")]
    public class Error : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 Id { get; set; }
        [DataMember]
        public String Mensaje { get; set; }
        [DataMember]
        public String Pila { get; set; }
        [DataMember]
        public String Excepcion { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }

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
}
