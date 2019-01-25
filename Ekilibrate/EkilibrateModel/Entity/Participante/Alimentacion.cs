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
    public class clsAlimentacionBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Boolean DESAYUNO { get; set; }
        [DataMember]
        public Boolean REFACCION_AM { get; set; }
        [DataMember]
        public Boolean ALMUERZO { get; set; }
        [DataMember]
        public Boolean REFACCION_TARDE { get; set; }
        [DataMember]
        public Boolean CENA { get; set; }
        [DataMember]
        public Boolean REFACCION_NOCHE { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingresa la cantidad de agua que consumes")]
        public Int32 ID_VASOS { get; set; }
        [DataMember]
        public Int32 CUCHARADAS_DIARIAS { get; set; }
        [DataMember]
        public Boolean SAL { get; set; }
        [DataMember]
        public String COMIDA_FAVORITA { get; set; }
        [DataMember]
        public String COMIDA_NO_FAVORITA { get; set; }
        [DataMember]
        public String COMIDA_DANINA { get; set; }
        
         Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return ID_PARTICIPANTE;
            }
            set
            {
                ID_PARTICIPANTE = value;
            }
        }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsAlimentacion : clsAlimentacionBase
    {
        public String PARTICIPANTE { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsAlimentacionFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }

}
