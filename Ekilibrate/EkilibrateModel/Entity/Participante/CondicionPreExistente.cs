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
    [DataContract(Namespace ="Ekilibrate.Model.Entity.Participante")]
    public class clsCondicionPreExistenteBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Int32 ID_CONDICION { get; set; }
        [DataMember]
        public String RESPUESTA { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get 
            {
                return ID_CONDICION;
            }
            set
            {
                ID_CONDICION = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]

    public sealed class clsCondicionPreExistente : clsCondicionBase
    {
        [DataMember]
        public Boolean Seleccionado { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsCondicionPreExistenteFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }
}
