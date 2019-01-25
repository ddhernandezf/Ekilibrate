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
    public class clsTipoEjercicio : IEntityPOCO<Int32>
    {
        [DataMember]
        public int ID_EJERCICIO { get; set; }
        [DataMember]
        public string NOMBRE_EJERCICIO { get; set; }

        Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ID_EJERCICIO;
            }
            set
            {
                ID_EJERCICIO = value;
            }
        }
    }
}