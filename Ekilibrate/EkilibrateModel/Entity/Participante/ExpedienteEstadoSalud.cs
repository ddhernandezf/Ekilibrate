using Ekilibrate.Data.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Model.Entity.Participante
{
    [DataContract(Namespace = "Ekilibrate.Model.Entity.Participante")]
    public class clsExpedienteEstadoSalud : IEntityPOCO<Int32>
    {

        [DataMember]
        public Int32 Id { get; set; }

        [DataMember]
        public int PT { get; set; }

        [DataMember]
        public string PTColor { get; set; }

        [DataMember]
        public string PTTexto { get; set; }

        [DataMember]
        public double PorcentajeGrasa { get; set; }

        [DataMember]
        public string PorcentajeGrasaColor { get; set; }

        [DataMember]
        public string PorcentajeGrasaTexto { get; set; }

        [DataMember]
        public int TGL { get; set; }

        [DataMember]
        public string TGLColor { get; set; }

        [DataMember]
        public string TGLTexto { get; set; }

        [DataMember]
        public int CHOL { get; set; }

        [DataMember]
        public string CHOLColor { get; set; }

        [DataMember]
        public string CHOLTexto { get; set; }

        [DataMember]
        public int GLI { get; set; }

        [DataMember]
        public string GLIColor { get; set; }

        [DataMember]
        public string GLITexto { get; set; }

        //[DataMember]
        //public string PA { get; set; }

        //[DataMember]
        //public string PAColor { get; set; }

        //[DataMember]
        //public string PATexto { get; set; }

        [DataMember]
        public int ConsumoCalorias { get; set; }

        [DataMember]
        public string ObservacionNutricional { get; set; }

        [DataMember]
        public int ConsumoAgua { get; set; }
        [DataMember]
        public string ConsumoAguaColor { get; set; }
        [DataMember]
        public string ConsumoAguaTexto { get; set; }
        [DataMember]
        public string ConsumoAguaImagen { get; set; }

        [DataMember]
        public double ConsumoAzucar { get; set; }
        [DataMember]
        public string ConsumoAzucarColor { get; set; }
        [DataMember]
        public string ConsumoAzucarTexto { get; set; }
        [DataMember]
        public string ConsumoAzucarImagen { get; set; }

        [DataMember]
        public bool ConsumoSal { get; set; }
        [DataMember]
        public string ConsumoSalColor { get; set; }
        [DataMember]
        public string ConsumoSalTexto { get; set; }
        [DataMember]
        public string ConsumoSalImagen { get; set; }

        [DataMember]
        public string ObservacionesHabitosAlimentarios { get; set; }


        [DataMember]
        public bool Fuma { get; set; }

        [DataMember]
        public bool Bebe { get; set; }

        [DataMember]
        public List<string> FactoresRiesgo { get; set; }

        [DataMember]
        public string ObservacionesFactoresRiesgo { get; set; }

        [DataMember]
        public int MinutosActividadFisica { get; set; }

        [DataMember]
        public List<string> CondicionesPrexistentes { get; set; }


        [DataMember]
        public string ObservacionesEstilovida { get; set; }

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
