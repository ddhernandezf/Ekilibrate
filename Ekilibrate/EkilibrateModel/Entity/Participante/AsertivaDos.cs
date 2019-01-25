﻿using System;
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
    public class clsAsertivaDosBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Int32 ID_PREGUNTA { get; set; }
        [DataMember]
        public Boolean SIEMPRE_LO_HAGO { get; set; }
        [DataMember]
        public Boolean HABITUALMENTEBIT { get; set; }
        [DataMember]
        public Boolean MITAD_VECES { get; set; }
        [DataMember]
        public Boolean RARAMENTE { get; set; }
        [DataMember]
        public Boolean NUNCA { get; set; }
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
    public sealed class clsAsertivaDos : clsAsertivaDosBase
    {
        [DataMember]
        public String PREGUNTA { get; set; }
    }
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]

    public sealed class clsAsertivaDosFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }
}
  
