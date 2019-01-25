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
    public class clsRiesgoBase : IEntityPOCO<Int32>
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
        [DataMember]
        [Display(Name = "¿Fumas con regularmente?:")]
        public Boolean FUMAR { get; set; }
        [DataMember]
        [Display(Name = "¿Con qué frecuencia?")]
        public String CODIGO_FRECUENCIA_FUMAR { get; set; }
        [DataMember]
        [Display(Name = "¿Cuántos cigarrillos fumas cada vez?")]
        public Int32 NUM_CIGARROS { get; set; }
        [DataMember]
        [Display(Name = "¿Tomas bebidas alcohólicas?")]
        public Boolean BEBER { get; set; }
        [DataMember]
        [Display(Name = "¿Con qué frecuencia?")]
        public String CODIGO_FRECUENTE_BEBER { get; set; }
        [DataMember]
        [Display(Name = "Si bebes, ¿Cuántas bebidas tomas?")]
        public Int32 NUMERO_BEBIDA { get; set; }

        [DataMember]
        public IEnumerable<clsBebidasFrecuentes> LISTA_BEBIDA { get; set; }

        [DataMember]
        public IEnumerable<clsMedidaBebida> LISTA_MEDIDA { get; set; }

        [DataMember]
        public IEnumerable<clsEnfermedad> LISTA_ENFERMEDAD { get; set; }

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
    public sealed class clsRiesgo : clsRiesgoBase
    {
        public String PARTICIPANTE { get; set; }


    }

    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public sealed class clsRiesgoFiltro : clsPaging
    {
        [DataMember]
        public Int32 ID_PARTICIPANTE { get; set; }
    }


}
