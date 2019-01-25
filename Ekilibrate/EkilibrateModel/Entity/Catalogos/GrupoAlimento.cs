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
    public class GrupoAlimento : IEntityPOCO<Int32>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string IconoURL { get; set; }
        [DataMember]
        public int Calorias { get; set; }
        [DataMember]
        public int Proteinas { get; set; }
        [DataMember]
        public int Carbohidratos { get; set; }
        [DataMember]
        public int Grasas { get; set; }
        [DataMember]
        public string NombreColumnaModelo { get; set; }

        Int32 IEntityPOCO<Int32>.Key 
        { 
            get { return Id; } 
            set { Id = value; } 
        }
    }
}