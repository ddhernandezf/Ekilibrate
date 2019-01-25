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
    public class clsActividadFisica : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public Boolean REALIZA_ACTIVIDAD { get; set; }
        [DataMember]
        public Int32? ID_PRINCIPAL { get; set; }
        [DataMember]
        public Int32? PRINCIPAL_VECES { get; set; }
        [DataMember]
        public Int32? PRINCIPAL_TIEMPO { get; set; }
        [DataMember]
        public Int32? ID_SECUNDARIO { get; set; }
        [DataMember]
        public Int32? SECUNDARIO_VECES { get; set; }
        [DataMember]
        public Int32? SECUNDARIO_TIEMPO { get; set; }
                
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
    public class clsPadecimiento : IEntityPOCO<Int32>
    {
        [DataMember]
        [ScaffoldColumn(false)]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        public string PADECIMIENTO_PRINCIPAL { get; set; }
        [DataMember]
        public string MEDICAMENTO_PRINCIPAL { get; set; }
        [DataMember]
        public string PADECIMIENTO_SECUNDARIO { get; set; }
        [DataMember]
        public string MEDICAMENTO_SECUNDARIO { get; set; }
        [DataMember]
        public bool TRATAMIENTO { get; set; }
        
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
    public sealed class clsCuidado
    {
        [DataMember]
        public clsActividadFisica ActividadFisica { get; set; }
        [DataMember]
        public clsPadecimiento Padecimiento { get; set; }
        
        [DataMember]
        public IEnumerable<clsCondicionPreExistente> ListadoCondiciones { get; set; }
    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsCuidadoFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }


}
