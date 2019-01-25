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
    [DataContract(Namespace = "Ekilibrate.Model.Entity.General")]
    public class CorreoElectronico : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public int? Puerto { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Operacion { get; set; }

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