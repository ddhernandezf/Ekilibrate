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
    public class clsPasosBase : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Se requiere la semana")]
        public int SemanaId { get; set; }
                
        [DataMember]
        [Required(ErrorMessage = "Se requiere el participante")]
        public int ParticipanteId { get; set; }
                
        [DataMember]
        public int Meta { get; set; }

        [DataMember]
        public int Caminados { get; set; }

        [DataMember]
        public int Registros { get; set; }

        [DataMember]
        public int Nota { get; set; }

        [DataMember]
        public int NotaCompa { get; set; }

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
